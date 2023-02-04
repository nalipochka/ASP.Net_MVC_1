using ASP.Net_MVC_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.Net_MVC_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILibrary<Book> library;

        public HomeController(ILogger<HomeController> logger, ILibrary<Book> library)
        {
            _logger = logger;
            this.library = library;
        }

        public IActionResult Library()
        {
            IEnumerable<Book> books = library.GetAll();
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            Book? book = library.Get(id);
            return View((Object)book!.More);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return Content("There aren`t all filled fields!");
            }
            int id = library.GetAll().Max(x => x.Id);
            book.Id = ++id;
            library.Add(book);
            return RedirectToAction("Library");
           
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book? book = library.Get(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            library.Edit(book);
            return RedirectToAction("Library");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Content("You must provide id of book!");
            }
            Book? book = library.Get(id.Value);
            return View(book);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (library.Delete(id.Value))
            {
                return RedirectToAction("Library");
            }
            else
            {
                return Content($"The book with id = {id.Value} is not exists!");
            }
            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}