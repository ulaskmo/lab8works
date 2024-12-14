namespace Lab8Library.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}