using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dairy_Malik_Mangement.Models;

namespace Dairy_Malik_Mangement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dairy_Malik_Mangement.Models.Milk> Milk { get; set; } = default!;
    }
}
