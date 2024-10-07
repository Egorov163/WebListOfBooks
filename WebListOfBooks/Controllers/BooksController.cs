using Microsoft.AspNetCore.Mvc;
using WebListOfBooks.Models.Books;
using WebListOfBooks.Services;

namespace WebListOfBooks.Controllers
{
    public class BooksController : Controller
    {
        private BookBuilder _bookBuilder;
        public BooksController(BookBuilder bookBuilder) 
        {
            _bookBuilder = bookBuilder;
        }
        
        public static List<BookViewModel> bookViewModels = new List<BookViewModel>();

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                Books = bookViewModels
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
            var newBook = new BookViewModel()
            {
                Name = bookViewModel.Name,
                Author = bookViewModel.Author
            };

            bookViewModels.Add(newBook);
            return RedirectToAction("Index");
        }

        public IActionResult AddExampleBook()
        {
            var newBook = _bookBuilder.BuildExampleBook();          
            bookViewModels.Add(newBook);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateAuthor(string author, string name)
        {
            var book = bookViewModels.First(x => x.Name == name);
            book.Author = author;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateName(string nameBook, string name)
        {
            var book = bookViewModels.First(x => x.Name == nameBook);
            book.Name = name;
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string name)
        {
            var book = bookViewModels.First(x => x.Name == name);
            bookViewModels.Remove(book);
            return RedirectToAction("Index");
        }
    }
}
