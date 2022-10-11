using Microsoft.EntityFrameworkCore;

namespace TestNugetConsumer.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Page> Pages { get; set; }
    }
}
