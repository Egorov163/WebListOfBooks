using Microsoft.AspNetCore.Mvc;
using WebListOfBooks.DbStuff;
using WebListOfBooks.DbStuff.Models;
using WebListOfBooks.Models.Books;
using WebListOfBooks.Services;

namespace WebListOfBooks.Controllers
{
    public class BooksController : Controller
    {
        private BookBuilder _bookBuilder;
        private WebDbContext _webDbContext;
        public BooksController(BookBuilder bookBuilder, WebDbContext webDbContext)
        {
            _bookBuilder = bookBuilder;
            _webDbContext = webDbContext;
        }

        public static List<BookViewModel> bookViewModels = new List<BookViewModel>();

        public IActionResult Index()
        {
            var dbBooks = _webDbContext.Books.Take(10).ToList();

            var bookViewModel = dbBooks.Select(dbBook => new BookViewModel
            {
                Id = dbBook.Id,
                Name = dbBook.Name,
                Author = dbBook.Author
            }).ToList();

            var viewModel = new IndexViewModel()
            {
                Books = bookViewModel
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(AddBookViewModel bookViewModel)
        {
            var book = new Book
            {
                Name = bookViewModel.Name,
                Author = bookViewModel.Author
            };
            _webDbContext.Add(book);
            _webDbContext.SaveChanges();
           
            return RedirectToAction("Index");
        }

        public IActionResult AddExampleBook()
        {
            var newBook = _bookBuilder.BuildExampleBook();
            bookViewModels.Add(newBook);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateAuthor(string author, int id)
        {
            var book = _webDbContext.Books.First(book => book.Id == id);
            book.Author = author;
            _webDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateName(int id, string name)
        {
            var book = _webDbContext.Books.First(book => book.Id == id);
            book.Name = name;
            _webDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var book = _webDbContext.Books.First(book=>book.Id==id);
            _webDbContext.Books.Remove(book);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
