using Microsoft.AspNetCore.Mvc;
using MovieRentalApplication.Data;
using MovieRentalApplication.Models;
using System.Linq;

namespace MovieRentalApplication.Controllers
{
    [ApiController]
    [Route("api/rental")]
    public class RentalController : ControllerBase
    {
        private readonly MovieRentalContext _context;

        public RentalController(MovieRentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRentals()
        {
            var rentals = _context.Rentals.ToList();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public IActionResult GetRental(int id)
        {
            var rental = _context.Rentals.FirstOrDefault(r => r.RentalID == id);
            if (rental == null)
                return NotFound();

            return Ok(rental);
        }

        [HttpPost]
        public IActionResult PostRental(Rental rental)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRental), new { id = rental.RentalID }, rental);
        }

        [HttpPut("{id}")]
        public IActionResult PutRental(int id, Rental rental)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existingRental = _context.Rentals.FirstOrDefault(r => r.RentalID == id);
            if (existingRental == null)
                return NotFound();

            existingRental.RentalDate = rental.RentalDate;
            existingRental.ReturnDate = rental.ReturnDate;
            existingRental.CustomerID = rental.CustomerID;

            _context.SaveChanges();

            return Ok(existingRental);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRental(int id)
        {
            var rental = _context.Rentals.FirstOrDefault(r => r.RentalID == id);
            if (rental == null)
                return NotFound();

            _context.Rentals.Remove(rental);
            _context.SaveChanges();

            return Ok(rental);
        }
    }
}
