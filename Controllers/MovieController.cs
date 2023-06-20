using Microsoft.AspNetCore.Mvc;
using MovieRentalApplication.Data;
using MovieRentalApplication.Models;
using System.Linq;

namespace MovieRentalApplication.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly MovieRentalContext _context;

        public MovieController(MovieRentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieID == id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.MovieID }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existingMovie = _context.Movies.FirstOrDefault(m => m.MovieID == id);
            if (existingMovie == null)
                return NotFound();

            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.Director = movie.Director;
            existingMovie.Description = movie.Description;

            _context.SaveChanges();

            return Ok(existingMovie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieID == id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok(movie);
        }
    }
}
