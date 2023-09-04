using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Movie.Models;

namespace MVC_Movie.Controllers
{
    public class MovieController : Controller
    {
        private MovieCRUD crud;
        private readonly IConfiguration configuration;

        public MovieController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new MovieCRUD(this.configuration);
        }
        public ActionResult Index()
        {
            var model = crud.GetAllMovies();
            return View(model);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            var result = crud.GetMovieById(id);
            return View(result);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                int result = crud.AddMovie(movie);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = crud.GetMovieById(id);
            return View(result);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                int result = crud.UpdateMovieDetails(movie);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else  return View(); 
               
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = crud.GetMovieById(id);
            return View(result);
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteMovie(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
