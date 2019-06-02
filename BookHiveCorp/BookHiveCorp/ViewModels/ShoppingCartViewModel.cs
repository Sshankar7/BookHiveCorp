using System.Collections.Generic;
using BookHiveCorp.Models;

namespace BookHiveCorp.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal    { get; set; }
    }
}