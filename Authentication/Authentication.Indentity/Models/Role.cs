using Microsoft.AspNetCore.Identity;

namespace Authentication.Identity.Models
{
    public class Role : IdentityRole<Guid>
    {
        public static string Administrator => "Administrator";
        public static string Manager => "Manager";
    }
}