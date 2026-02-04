using Microsoft.EntityFrameworkCore;
using User_CRUD.Model;

namespace User_CRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> users { get; set; }
    }
}
