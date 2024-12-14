using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab8WebApp.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public async Task OnGetAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            Response.Redirect("/Account/Login");
        }
    }
}