using Microsoft.EntityFrameworkCore;
using WebListOfBooks.DbStuff.Models;

namespace WebListOfBooks.DbStuff
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions options): base(options) { }    

        public DbSet<Book> Books { get; set; }
    }
}
