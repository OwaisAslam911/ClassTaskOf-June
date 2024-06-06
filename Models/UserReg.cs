namespace ClassTaskOf_June.Models
{
    public class UserReg
    {
        public User UserRegView { get; set; }
        public IEnumerable<UserRole> Roles { get; set; }
    }
}
