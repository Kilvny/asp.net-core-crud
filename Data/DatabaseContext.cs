using ASP.NET_CORE_Course.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_Course.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<ItemModel> Items { get; set; }
    }
}
