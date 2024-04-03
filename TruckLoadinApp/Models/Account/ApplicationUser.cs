using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckLoadinApp.Models.Account
{
    public class ApplicationUser
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        public string? Password { get; set; }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


       
        [NotMapped]
        public string? SuccessMessage { get; set; }
        [NotMapped]
        public string? ErrorMessage { get; set; }
    }
}
