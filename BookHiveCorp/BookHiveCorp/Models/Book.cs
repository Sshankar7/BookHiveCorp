using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookHiveCorp.Models
{
    public class Book
    {
        [ScaffoldColumn(false)]

        public int BookId { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [Range(0.01, 100.00)]

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Book Art URL")]
        [StringLength(1024)]
        public string BookArtUrl { get; set; }

        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}