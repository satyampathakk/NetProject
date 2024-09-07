using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using myapp.Models; // Adjust namespace to match your project
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myapp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Detail> Details { get; set; }

        public async Task OnGetAsync()
        {
            Details = await _context.Details.ToListAsync();
        }
    }
}
