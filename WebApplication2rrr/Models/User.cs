using Microsoft.EntityFrameworkCore;

namespace WebApplication2rrr.Models
{
    [Index(nameof(Login), IsUnique = true)]
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Sex { get; set; }
        public string Role { get; set; }
        public string NumberTelephone { get; set; }
    }
}
