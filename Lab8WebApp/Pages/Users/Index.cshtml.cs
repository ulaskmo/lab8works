using Lab8Library.Models; // Ensure the namespace for User is correct
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab8Library.Data;
using Microsoft.EntityFrameworkCore;


namespace Lab8WebApp.Pages.Users
{
    public class IndexModel : PageModel
    {
        public IList<User> Users { get; set; } = new List<User>();
        
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}