using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab8Library.Data;
using Lab8Library.Models;

namespace Lab8WebApp.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly Lab8Library.Data.ApplicationDbContext _context;

        public IndexModel(Lab8Library.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
