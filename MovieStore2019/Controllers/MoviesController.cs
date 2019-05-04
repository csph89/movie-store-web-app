using MovieStore2019.Models;
using MovieStore2019.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStore2019.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context { get; set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        // GET: Movies/Details/id
        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        // GET: The empty form to create a new movie.
        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(), //The properties of the Movie object will have the default values
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        // GET:
        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var genres = _context.Genres.ToList();

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        // POST: Create a new Customer or Update an existing one.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0) //An to Id einai 0 tote shmainei oti den exei parei timh to Id epomenws den exei ginei eggrafh sth vash mas.
            {
                //PROSOXH!!
                //Edw prepei na arxikopoihsw osa Required-Properties exw sto Movie entity ta opoia den arxikopoiountai mesw ths formas.
                //Gia paradeigma an eixa kai to property Genre ws Required tha eprepe epipleon na grapsw: movie.Genre = _context.Genres.First( g => g.Id == movie.GenreId );
                //Alliws tha epairna null pointer exception otan tha ginotan klhsh tou movie.Genre.Name sto Index view
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}