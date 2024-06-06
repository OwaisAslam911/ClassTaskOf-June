using System;
using System.Collections.Generic;

namespace ClassTaskOf_June.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
