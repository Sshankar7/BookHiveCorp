using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookHiveCorp.Models;

namespace BookHiveCorp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private readonly BookHiveCorpEntities _storeContext = new BookHiveCorpEntities();

        // GET: /StoreManager/
        public async Task<ActionResult> Index()
        {
            return View(await _storeContext.Books
                .Include(a => a.Category)
                .Include(a => a.Author)
                .OrderBy(a => a.Price).ToListAsync());
        }

        // GET: /StoreManager/Details/5
        public async Task<ActionResult> Details(int id = 0)
        {
            var book = await _storeContext.Books.FindAsync(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // GET: /StoreManager/Create
        public async Task<ActionResult> Create()
        {
            return await BuildView(null);
        }

        // POST: /StoreManager/Create
        [HttpPost]
        public async Task<ActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _storeContext.Books.Add(book);

                await _storeContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return await BuildView(book);
        }

        // GET: /StoreManager/Edit/5
        public async Task<ActionResult> Edit(int id = 0)
        {
            var book = await _storeContext.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return await BuildView(book);
        }

        // POST: /StoreManager/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _storeContext.Entry(book).State = EntityState.Modified;

                await _storeContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return await BuildView(book);
        }

        // GET: /StoreManager/Delete/5
        public async Task<ActionResult> Delete(int id = 0)
        {
            var book = await _storeContext.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // POST: /StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var book = await _storeContext.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            _storeContext.Books.Remove(book);

            await _storeContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private async Task<ActionResult> BuildView(Book book)
        {
            ViewBag.CategoryId = new SelectList(
                await _storeContext.Categories.ToListAsync(),
                "CategoryId",
                "Name",
                book == null ? null : (object)book.CategoryId);

            ViewBag.AuthorId = new SelectList(
                await _storeContext.Authors.ToListAsync(),
                "AuthorId",
                "Name",
                book == null ? null : (object)book.AuthorId);

            return View(book);
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