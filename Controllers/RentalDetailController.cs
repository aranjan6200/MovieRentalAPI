using Microsoft.AspNetCore.Mvc;
using MovieRentalApplication.Data;
using MovieRentalApplication.Models;
using System.Linq;

namespace MovieRentalApplication.Controllers
{
    [ApiController]
    [Route("api/rentaldetail")]
    public class RentalDetailController : ControllerBase
    {
        private readonly MovieRentalContext _context;

        public RentalDetailController(MovieRentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRentalDetails()
        {
            var rentalDetails = _context.RentalDetails.ToList();
            return Ok(rentalDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetRentalDetail(int id)
        {
            var rentalDetail = _context.RentalDetails.FirstOrDefault(rd => rd.RentalDetailID == id);
            if (rentalDetail == null)
                return NotFound();

            return Ok(rentalDetail);
        }

        [HttpPost]
        public IActionResult PostRentalDetail(RentalDetail rentalDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.RentalDetails.Add(rentalDetail);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRentalDetail), new { id = rentalDetail.RentalDetailID }, rentalDetail);
        }

        [HttpPut("{id}")]
        public IActionResult PutRentalDetail(int id, RentalDetail rentalDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existingRentalDetail = _context.RentalDetails.FirstOrDefault(rd => rd.RentalDetailID == id);
            if (existingRentalDetail == null)
                return NotFound();

            existingRentalDetail.RentalID = rentalDetail.RentalID;
            existingRentalDetail.MovieID = rentalDetail.MovieID;

            _context.SaveChanges();

            return Ok(existingRentalDetail);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRentalDetail(int id)
        {
            var rentalDetail = _context.RentalDetails.FirstOrDefault(rd => rd.RentalDetailID == id);
            if (rentalDetail == null)
                return NotFound();

            _context.RentalDetails.Remove(rentalDetail);
            _context.SaveChanges();

            return Ok(rentalDetail);
        }
    }
}
