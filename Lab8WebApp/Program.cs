using Microsoft.EntityFrameworkCore;
using Lab8Library.Data; // For ApplicationDbContext
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages();

// Add authentication and configure cookie authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Redirect to Login page
        options.LogoutPath = "/Account/Logout"; // Redirect to Logout page
    });

var app = builder.Build();

// Configure middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();