using System;
using System.Collections.Generic;

namespace ClassTaskOf_June.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Carts = new HashSet<Cart>();
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
