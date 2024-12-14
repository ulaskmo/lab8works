using Lab8Library.Data;
using Lab8Library.Models;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseSqlite("Data Source=../Lab8WebApp/Lab8.db")
    .Options;

using var context = new ApplicationDbContext(options);

// Seed Data
if (!context.Users.Any())
{
    var category = new Category { Name = "Electronics" };
    var product = new Product { Name = "Smartphone", Price = 799.99M, Categories = new List<Category> { category } };
    var user = new User { Name = "Alice", Email = "alice@example.com" };
    var order = new Order { OrderNumber = "ORD123", User = user, Products = new List<Product> { product } };

    context.Categories.Add(category);
    context.Products.Add(product);
    context.Users.Add(user);
    context.Orders.Add(order);

    context.SaveChanges();
}

Console.WriteLine("Database seeded successfully!");