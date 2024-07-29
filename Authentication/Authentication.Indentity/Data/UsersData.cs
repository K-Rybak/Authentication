using Authentication.Identity.Models;

namespace Authentication.Identity.Data
{
    public static class UsersData
    {
        public static List<User> Users => new List<User>
        {
            new User("admin", "admin", Role.Administrator),
            new User("manager", "123", Role.Manager)
        };
    }
}
