using Microsoft.EntityFrameworkCore;
using WebListOfBooks.DbStuff.Models;

namespace WebListOfBooks.DbStuff
{
    public class WebDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public WebDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(user => user.Books)
                .WithOne(book => book.User);



            base.OnModelCreating(builder);
        }
    }
}
