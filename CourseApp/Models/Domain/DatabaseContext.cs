using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options ) : base(options)
        {
            
        }

        public DbSet<Courses> Courses { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
