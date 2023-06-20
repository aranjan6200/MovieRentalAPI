using Microsoft.AspNetCore.Mvc;
using MovieRentalApplication.Data;
using MovieRentalApplication.Models;
using System.Linq;

namespace MovieRentalApplication.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly MovieRentalContext _context;

        public CustomerController(MovieRentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerID }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existingCustomer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            if (existingCustomer == null)
                return NotFound();

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Address = customer.Address;

            _context.SaveChanges();

            return Ok(existingCustomer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok(customer);
        }
    }
}
