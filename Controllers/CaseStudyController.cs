using Microsoft.AspNetCore.Mvc;
using Portfoli.Models;
using portfolio.Data;
using portfolio.Models;

// For more information on enabling Web API for empty CaseStudy, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfoli.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseStudyController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CaseStudyController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<CaseStudyController>
        [HttpGet]
        public IActionResult GetAll() => Ok(_context.CaseStudy.ToList());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.CaseStudy.Find(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Create(CaseStudy caseStudy)
        {
            _context.CaseStudy.Add(caseStudy);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = caseStudy.Id }, caseStudy);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CaseStudy updatedProduct)
        {
            var product = _context.CaseStudy.Find(id);
            if (product == null) return NotFound();

            product.title = updatedProduct.title;
            product.problem = updatedProduct.problem;
            product.solution = updatedProduct.solution;
            product.outcome = updatedProduct.outcome;
            product.imageUrl = updatedProduct.imageUrl;
            product.imageHint = updatedProduct.imageHint;
            product.tags = updatedProduct.tags ?? new List<string>(); // Ensure Tags is not null
            product.tags.AddRange(updatedProduct.tags ?? new List<string>()); // Add new tags if any
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.CaseStudy.Find(id);
            if (product == null) return NotFound();

            _context.CaseStudy.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
