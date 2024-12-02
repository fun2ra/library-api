using BasicLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicLibrary.Contexts
{
    public class LibraryDbContext : DbContext

    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }
        public DbSet<Author> Authors {  get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
