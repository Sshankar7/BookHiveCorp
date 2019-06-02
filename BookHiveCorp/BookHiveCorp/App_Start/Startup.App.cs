using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using BookHiveCorp.Models;
using Owin;

[assembly: OwinStartup(typeof(BookHiveCorp.App_Start.Startup))]

namespace BookHiveCorp.App_Start
{
    public partial class Startup
    {
        private const string RoleName = "Administrator";

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication();


            using (var context = new BookHiveCorpEntities())
            {
                context.Database.Delete();
                context.Database.Create();

                new SampleData().Seed(context);
            }

            CreateAdminUser().Wait();
        }


        private async Task CreateAdminUser()
        {
            var username = ConfigurationManager.AppSettings["DefaultAdminUsername"];
            var password = ConfigurationManager.AppSettings["DefaultAdminPassword"];

            using (var context = new ApplicationDbContext())
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                var role = new IdentityRole(RoleName);
                
                var result = await roleManager.RoleExistsAsync(RoleName);
                if (!result)
                {
                    await roleManager.CreateAsync(role);
                }

                var user = await userManager.FindByNameAsync(username);
                if (user == null)
                {
                    user = new ApplicationUser { UserName = username };
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user.Id, RoleName);
                }
            }
        }

    }
}
