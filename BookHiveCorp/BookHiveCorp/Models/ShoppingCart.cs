using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookHiveCorp.Models
{
    public class ShoppingCart
    {
        public const string CartSessionKey = "CartId";

        private readonly BookHiveCorpEntities _storeContext;
        private readonly string _cartId;

        private ShoppingCart(BookHiveCorpEntities storeContext, string cartId)
        {
            _storeContext = storeContext;
            _cartId = cartId;
        }

        public static ShoppingCart GetCart(BookHiveCorpEntities storeContext, Controller controller)
        {
            return new ShoppingCart(storeContext, GetCartId(controller.HttpContext));
        }

        private static string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                var username = context.User.Identity.Name;

                context.Session[CartSessionKey] = !string.IsNullOrWhiteSpace(username)
                    ? username
                    : Guid.NewGuid().ToString();
            }

            return context.Session[CartSessionKey].ToString();
        }

        public async Task AddToCart(Book book)
        {
            var cartItem = await GetCartItem(book.BookId);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    BookId = book.BookId,
                    CartId = _cartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                _storeContext.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
        }

        public async Task<int> RemoveFromCart(int id)
        {
            var cartItem = await GetCartItem(id);

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    return --cartItem.Count;
                }

                _storeContext.Carts.Remove(cartItem);
            }

            return 0;
        }

        private Task<Cart> GetCartItem(int bookId)
        {
            return _storeContext.Carts.SingleOrDefaultAsync(
                c => c.CartId == _cartId && c.BookId == bookId);
        }

        public IQueryable<Cart> GetCartItems()
        {
            return _storeContext.Carts.Where(c => c.CartId == _cartId);
        }

        public Task<int> GetCount()
        {
            return _storeContext.Carts
                .Where(c => c.CartId == _cartId)
                .Select(c => c.Count)
                .SumAsync();
        }

        public Task<decimal> GetTotal()
        {
            return _storeContext.Carts
                .Where(c => c.CartId == _cartId)
                .Select(c => c.Count * c.Book.Price)
                .SumAsync();
        }

        public async Task<int> CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = await _storeContext.Carts
                .Where(c => c.CartId == _cartId)
                .Include(c => c.Book)
                .ToListAsync();

            foreach (var item in cartItems)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    BookId = item.BookId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Book.Price,
                    Quantity = item.Count,
                });

                orderTotal += item.Count * item.Book.Price;
            }

            order.Total = orderTotal;

            await EmptyCart();

            return order.OrderId;
        }

        private async Task EmptyCart()
        {
            foreach (var cartItem in await _storeContext.Carts.Where(
                c => c.CartId == _cartId).ToListAsync())
            {
                _storeContext.Carts.Remove(cartItem);
            }
        }

        public async Task MigrateCart(string userName)
        {
            var carts = await _storeContext.Carts.Where(c => c.CartId == _cartId).ToListAsync();

            foreach (var item in carts)
            {
                item.CartId = userName;
            }

            await _storeContext.SaveChangesAsync();
        }
    }
}