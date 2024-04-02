using System.ComponentModel.DataAnnotations;

namespace TruckLoadinApp.Models.Account
{
    public class ApplicationUser
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
