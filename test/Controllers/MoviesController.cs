using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oceans.Models;
using test.Models;
using test.ViewModels;

namespace test.Controllers
{

    public class MoviesController : Controller
    {
        private MyDbContext _context;

        public MoviesController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("movies")]
        public ActionResult MoviesList()
        {
            var moviesList = _context.Movies.ToList();
            var GenreType = _context.Genre.ToList();
            
            var viewMovies = new MoviesViewModel
            {
                Movies = moviesList,
                Genres = GenreType
            };

            return View("moviesView", viewMovies);
        }

         // GET : /movies/new
        [Route("movies/new")]

        public ActionResult NewMovie()
        {
            var GenreList = _context.Genre.ToList();

            var ViewModel = new NewMovieViewModel
            {
                Genre = GenreList,
                Movie = new Movie
                {
                    ReleaseDate = "1 Jan 2001",
                    NumberInStock = 1
                }
            };

            return View(ViewModel);
        }

        [Route("movies/edit/{id}")]
        public ActionResult EditMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var GenreList = _context.Genre.ToList();
            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genre = GenreList
            };

            if (movie == null) return HttpNotFound();

            return View("newMovie",viewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid) // validation error
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    Genre = _context.Genre.ToList()
                };
                return View("newMovie",viewModel);
            }

            if (movie.Id == 0) // if its a new movie with no Id
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.NumberInStock = movie.NumberInStock;
                MovieInDb.Genre = movie.Genre;
            }

            _context.SaveChanges();
            return RedirectToAction("MoviesList", "Movies");
        }
    }
}