using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission_6.Models;
using SQLitePCL;
using System.Linq;

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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges(); 

            return View("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(x => x.MovieId == id);
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("MovieForm", movie);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Single(x => x.MovieId == id);
            return View(movie);
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

            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("MovieForm", updatedInfo);
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