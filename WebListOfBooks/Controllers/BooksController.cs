using Microsoft.AspNetCore.Mvc;
using WebListOfBooks.Models.Books;

namespace WebListOfBooks.Controllers
{
    public class BooksController : Controller
    {
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
    }
}
