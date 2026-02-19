using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission_6.Models;
using System.Linq;

namespace Mission_6.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            // Gets the movies and includes the Category object for the list view
            var movies = _context.Movies
                .Include(m => m.Category)
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
            // FIX: Populate categories for the dropdown menu
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            // FIX: Return the View instead of redirecting so the user can see the form
            return View("MovieForm", new Movie());
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (ModelState.IsValid) // Check for Required fields and Year > 1888
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                // FIX: Use RedirectToAction to refresh the list correctly
                return RedirectToAction("Index");
            }

            // If invalid, stay on the form and pass categories back
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(x => x.MovieId == id);

            // Send categories for the dropdown
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View("MovieForm", movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedInfo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // If invalid, reload the form with the categories
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("MovieForm", updatedInfo);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Single(x => x.MovieId == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}