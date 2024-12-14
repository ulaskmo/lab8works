using Lab8Library.Data;
using Lab8Library.Models;
using Microsoft.EntityFrameworkCore;

// Ensure the database context is configured
var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseSqlite("Data Source=../Lab8WebApp/Lab8.db")
    .Options;

using var context = new ApplicationDbContext(options);

// Display all users
Console.WriteLine("Users:");
var users = context.Users.ToList();
foreach (var user in users)
{
    Console.WriteLine($"- {user.Name} ({user.Email})");
}

// Retrieve all products in a specific category
Console.WriteLine("\nProducts in Electronics Category:");
var electronicsProducts = context.Products
    .Where(p => p.Categories.Any(c => c.Name == "Electronics"))
    .ToList();
foreach (var product in electronicsProducts)
{
    Console.WriteLine($"- {product.Name}: ${product.Price}");
}

// Retrieve all orders for a specific user
Console.WriteLine("\nOrders for User 'ulasasas':");
var ordersForUser = context.Orders
    .Include(o => o.Products)
    .Where(o => o.User.Name == "ulasasas")
    .ToList();
foreach (var order in ordersForUser)
{
    Console.WriteLine($"Order {order.OrderNumber} contains:");
    foreach (var product in order.Products)
    {
        Console.WriteLine($"- {product.Name}");
    }
}

// Find the most expensive product in a category
Console.WriteLine("\nMost Expensive Product in Electronics:");
var mostExpensiveProduct = context.Products
    .Where(p => p.Categories.Any(c => c.Name == "Electronics"))
    .OrderByDescending(p => p.Price)
    .FirstOrDefault();
if (mostExpensiveProduct != null)
{
    Console.WriteLine($"{mostExpensiveProduct.Name}: ${mostExpensiveProduct.Price}");
}