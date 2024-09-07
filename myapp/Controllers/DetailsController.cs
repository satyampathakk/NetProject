using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myapp.Models; // Adjust namespace to match your project
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace myapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/details
        [HttpGet]
        public async Task<IActionResult> GetAllDetails()
        {
            var details = await _context.Details.ToListAsync();
            return Ok(details); // Returns data in JSON format
        }

        // POST: api/details
        [HttpPost]
        public async Task<IActionResult> CreateDetail([FromBody] Detail detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Details.Add(detail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllDetails), new { id = detail.Id }, detail);
        }

        // GET: api/details/csv
        [HttpGet("csv")]
        public async Task<IActionResult> GetDetailsAsCsv()
        {
            var details = await _context.Details.ToListAsync();

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Id,Name,Email,PhoneNumber,Remarks,RequestTime");

            foreach (var detail in details)
            {
                csvBuilder.AppendLine($"{detail.Id},{detail.Name},{detail.Email},{detail.PhoneNumber},{detail.Remarks},{detail.RequestTime}");
            }

            var csvBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            var stream = new MemoryStream(csvBytes);

            return File(stream, "text/csv", "details.csv");
        }
    }
}
