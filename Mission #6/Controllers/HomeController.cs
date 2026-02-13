using Microsoft.AspNetCore.Mvc;
using Mission_6.Models;

namespace Mission_6.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index() => View();

        public IActionResult GetToKnowJoel() => View();

        [HttpGet]
        public IActionResult MovieForm() => View();

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges(); 

            return View("Index");
        }
    }
}