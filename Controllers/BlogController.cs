using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using portfolio.Data;
using portfolio.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Blogs.ToList());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Blogs.Find(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Blog Blog)
        {
            _context.Blogs.Add(Blog);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = Blog.Id }, Blog);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Blog updatedProduct)
        {
            var product = _context.Blogs.Find(id);
            if (product == null) return NotFound();

            product.title = updatedProduct.title;
            product.summary = updatedProduct.summary;
            product.author = updatedProduct.author;
            product.slug = updatedProduct.slug;
            product.imageUrl = updatedProduct.imageUrl;
            product.imageHint = updatedProduct.imageHint;
            product.publishedAt = DateTime.UtcNow;
            product.skill = updatedProduct.skill ?? new List<string>(); // Ensure Tags is not null
            product.skill.AddRange(updatedProduct.skill ?? new List<string>()); // Add new tags if any

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Projects.Find(id);
            if (product == null) return NotFound();

            _context.Projects.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
