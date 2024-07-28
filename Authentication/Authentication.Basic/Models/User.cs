namespace Authentication.Basic.Models
{
    public class User
    {
        public User(string name, string password, string role)
        {
            Name = name;
            Password = password;
            Role = role;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
