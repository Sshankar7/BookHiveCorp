using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookHiveCorp.Models;

namespace BookHiveCorp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookHiveCorpEntities _storeContext = new BookHiveCorpEntities();

        // GET: /Home/
        public async Task<ActionResult> Index()
        {
            return View(await _storeContext.Books
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(6)
                .ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _storeContext.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}