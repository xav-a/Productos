namespace Productos.Server.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int? WishlistId { get; set; }

        public virtual Category Category { get; set; } = new();
    }
}
