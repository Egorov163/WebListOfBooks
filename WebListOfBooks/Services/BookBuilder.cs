using WebListOfBooks.DbStuff.Models;
using WebListOfBooks.Models.Books;

namespace WebListOfBooks.Services
{
    public class BookBuilder
    {
        public Book BuildExampleBook()
        {
            var book = new Book()
            {
                Name = "Название книги",
                Author = "Автор книги"
            };
            return book;
        }
    }
}
