namespace Lab8Library.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Many-to-Many Relationship: A Product can belong to multiple Orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        // Many-to-Many Relationship: A Product can belong to multiple Categories
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}