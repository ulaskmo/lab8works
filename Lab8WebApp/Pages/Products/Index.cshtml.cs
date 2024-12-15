using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab8Library.Data;
using Lab8Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab8WebApp.Pages.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Products = await _context.Products
                .Include(p => p.Categories) // Include related categories
                .ToListAsync();
        }
    }
}