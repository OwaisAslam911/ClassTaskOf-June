﻿using System;
using System.Collections.Generic;

namespace ClassTaskOf_June.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }
        public int? CategoryId { get; set; }

        public virtual ProductCategory? Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
