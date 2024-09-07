using Microsoft.EntityFrameworkCore;

namespace myapp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Detail> Details { get; set; }
    }
}
