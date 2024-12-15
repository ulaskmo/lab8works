using Microsoft.EntityFrameworkCore;
using Lab8Library.Data; // For ApplicationDbContext
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages(options =>
{
    // Require authentication globally
    options.Conventions.AuthorizeFolder("/");
    options.Conventions.AllowAnonymousToPage("/Account/Login"); // Allow anonymous access to the Login page
    options.Conventions.AllowAnonymousToPage("/Account/Logout"); // Allow access to Logout page (optional)
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Redirect to Login page
        options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect to Access Denied page
    });

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();