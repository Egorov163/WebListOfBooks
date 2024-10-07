using WebListOfBooks.Models.Books;

namespace WebListOfBooks.Services
{
    public class BookBuilder
    {
        public BookViewModel BuildExampleBook()
        {
            var book = new BookViewModel()
            {
                Name = "Название книги",
                Author = "Автор книги"
            };
            return book;
        }
    }
}
