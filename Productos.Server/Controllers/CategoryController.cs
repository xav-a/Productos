using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productos.Server.Entity;
using Productos.Server.Models;

namespace Productos.Server.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(
            ILogger<CategoryController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public Task<IEnumerable<Category>> Get()
        {
            var dbSet = _dbContext.Set<Category>();
            return dbSet.ToListAsync().ContinueWith(t => t.Result as IEnumerable<Category>);
        }
    }
}
