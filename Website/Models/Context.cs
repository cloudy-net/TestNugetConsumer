using Microsoft.EntityFrameworkCore;

namespace Website.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Page> Pages { get; set; }
    }
}
