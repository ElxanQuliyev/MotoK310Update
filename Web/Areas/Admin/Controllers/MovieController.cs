using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class MovieController : Controller
    {
        
        private readonly MovieManager _movieManager;
        private readonly CategoryManager _categoryManager;

        public MovieController(MovieManager movieManager, CategoryManager categoryManager)
        {
            _movieManager = movieManager;
            _categoryManager = categoryManager;
        }

        // GET: MovieController
        public async Task<ActionResult> Index()
        {
            var movies = await _movieManager.GetAllAsync();
            return View(movies);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        
        // GET: MovieController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.CategoryList = await _categoryManager.GetAllAsync();
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movie movie,int[] categoryIds)
        {
            try
            {

                //All 
                //Any
                movie.MovieToCategories = new List<MovieToCategory>();

                movie.MovieToCategories.AddRange(
                    categoryIds.Select(c=>new MovieToCategory() {CategoryId=c,MovieId=movie.Id }).ToArray());

                await _movieManager.Add(movie);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryList = await _categoryManager.GetAllAsync();
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
