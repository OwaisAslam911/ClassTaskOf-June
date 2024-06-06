using System;
using System.Collections.Generic;

namespace ClassTaskOf_June.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Quantity { get; set; }

        public virtual ProductCategory? Category { get; set; }
        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
