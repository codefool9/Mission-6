using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission__6.Models;

namespace Mission__6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Get the request identifier (may be null)
            string requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            // Try to parse to int; use 0 if parsing fails
            int movieId = int.TryParse(requestId, out var parsed) ? parsed : 0;

            return View(new Movie { MovieId = movieId });
        }
    }
}
