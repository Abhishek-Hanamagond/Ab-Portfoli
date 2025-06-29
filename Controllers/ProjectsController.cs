using Microsoft.AspNetCore.Mvc;
using portfolio.Data;
using portfolio.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Projects.ToList());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Projects.Find(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Projects Project)
        {
            _context.Projects.Add(Project);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = Project.ID }, Project);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Projects updatedProduct)
        {
            var product = _context.Projects.Find(id);
            if (product == null) return NotFound();

            product.Title = updatedProduct.Title;
            product.Description = updatedProduct.Description;
            product.ImagePath = updatedProduct.ImagePath;
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
