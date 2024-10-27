using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productos.Server.Entity;
using Productos.Server.Models;

namespace Productos.Server.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public ProductController(
            ILogger<ProductController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public Task<IEnumerable<Product>> Get()
        {
            var dbSet = _dbContext.Set<Product>();
            return dbSet.ToListAsync().ContinueWith(t => t.Result as IEnumerable<Product>);
        }

        [HttpGet("category/{id}")]
        public Task<IEnumerable<Product>> GetByCategory(int categoryId)
        {
            var dbSet = _dbContext
                .Set<Product>()
                .Where(p => p.CategoryId == categoryId);
            return dbSet.ToListAsync().ContinueWith(t => t.Result as IEnumerable<Product>);
        }

        [HttpGet("{id}")]
        public ValueTask<Product?> Get(int id)
        {
            var dbSet = _dbContext.Set<Product>();
            return dbSet.FindAsync(id);
        }
    }
}
