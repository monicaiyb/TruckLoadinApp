using Microsoft.EntityFrameworkCore;
using TruckLoadinApp.Models.Account;

namespace TruckLoadinApp.Models
{
    public class TruckLoadingContextDb : DbContext
    {
        public TruckLoadingContextDb(DbContextOptions<TruckLoadingContextDb> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
