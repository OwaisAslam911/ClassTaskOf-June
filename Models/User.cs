using System;
using System.Collections.Generic;

namespace ClassTaskOf_June.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public int? RoleId { get; set; }

        public virtual UserRole? Role { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
