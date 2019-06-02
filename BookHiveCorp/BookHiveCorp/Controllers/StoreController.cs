using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookHiveCorp.Models;

namespace BookHiveCorp.Controllers
{
    public class StoreController : Controller
    {
        private readonly BookHiveCorpEntities _storeContext = new BookHiveCorpEntities();

        // GET: /Store/
        public async Task<ActionResult> Index()
        {
            return View(await _storeContext.Categories.ToListAsync());
        }

        // GET: /Store/Browse?category=Fiction
        public async Task<ActionResult> Browse(string category)
        {
            return View(await _storeContext.Categories.Include("Books").SingleAsync(c => c.Name == category));
        }

        public async Task<ActionResult> Details(int id)
        {
            var book = await _storeContext.Books.FindAsync(id);

            return book != null ? View(book) : (ActionResult)HttpNotFound();
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            return PartialView(
                _storeContext.Categories.OrderByDescending(
                    c => c.Books.Sum(a => a.OrderDetails.Sum(od => od.Quantity))).Take(9).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _storeContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}