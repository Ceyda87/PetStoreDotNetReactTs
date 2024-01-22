using backend.Context;
using backend.Entities;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateUpdateProductModel createUdateProductModel)
        {
            var product = new ProductEntity()
            {
                Brand = createUdateProductModel.Brand,
                Title = createUdateProductModel.Title,
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok("Product Saved Successfully");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetAllProducts()
        {
            var products = await _context.Products.OrderByDescending(q => q.CreatedDate).ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound("Product Not Found");
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, CreateUpdateProductModel createUpdateProductModel)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
           
            if (product == null)
            {
                return NotFound("Product Not Found");
            }
           product.Title = createUpdateProductModel.Title;
           product.Brand = createUpdateProductModel.Brand;
           product.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok("Product Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x=>x.Id == id);

            if(product == null)
            {
                return NotFound("Product Not Found");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok("Product deleted Successfully");
        }
    }
}
