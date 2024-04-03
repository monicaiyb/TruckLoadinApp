using TruckLoadinApp.Models;
using TruckLoadinApp.Models.Account;

namespace TruckLoadinApp.ViewModels
{
    public class AccountViewModel
    {
        public string? ErrorMessage { get; set; }
        public string? SuccessMessage { get; set; }
        public string? SearchTerm { get; set; }
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
       


        public void LoadUsers(TruckLoadingContextDb context)
        {
            
            Users = context.ApplicationUser.ToList();
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Users = Users.Where(r => r.Email.ToLower().Contains(SearchTerm.Trim().ToLower())
                                         || r.FirstName.ToLower().Contains(SearchTerm.Trim().ToLower())
                                        ).ToList();
            }

            
        }
    }
}
