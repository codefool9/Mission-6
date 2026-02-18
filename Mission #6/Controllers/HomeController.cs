using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        { 
            // This gets the display for the movies for Joel to view
            var movies = _context.Movies
                .Include(m => m.CategoryId)
                .OrderBy(m => m.Title)
                .ToList();

            return View(movies);
        }

        public IActionResult GetToKnowJoel()
        { 
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();        
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges(); 

            return View("Index");
        }
    }
}