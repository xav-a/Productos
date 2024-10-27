namespace Productos.Server.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
