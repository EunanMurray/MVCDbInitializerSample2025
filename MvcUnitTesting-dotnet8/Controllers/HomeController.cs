using Microsoft.AspNetCore.Mvc;
using MvcUnitTesting_dotnet8.Models;
using System.Diagnostics;
using Tracker.WebAPIClient;

namespace MvcUnitTesting_dotnet8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository<Book> repository;

        public HomeController(IRepository<Book> bookRepo, ILogger<HomeController> logger)
        {

            ActivityAPIClient.Track(StudentID: "S00235207", StudentName: "Eunan Murray", activityName: "Rad302 2025 Week2 Lab1", Task: "Running Initial Tests");
            repository = bookRepo;
            _logger = logger;
        }
        
        public IActionResult Index(string Genre = null)
        {
            var books = repository.GetAll();

            if (Genre != null)
            {
                books = books.Where(b => b.Genre == Genre);
            }

            ViewData["Genre"] = "Fiction";

            return View(books);
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Your Privacy is our concern";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
