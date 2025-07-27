using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survivor.Context;
using Survivor.Entities;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CategoryController(SurvivorDbContext context)
        {
            _context = context;
        }


        // GET: api/Category
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories
                .Where(c => !c.IsDeleted)
                .ToList();
            return Ok(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories
                .FirstOrDefault(c => c.Id == id && !c.IsDeleted);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryEntity category)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.Name))
            {
                return BadRequest("Invalid category data.");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryEntity category)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.Name))
            {
                return BadRequest("Invalid category data.");
            }
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = category.Name;
            existingCategory.ModifiedDate = DateTime.UtcNow;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
            if (category == null)
            {
                return NotFound();
            }
            category.IsDeleted = true;
            category.ModifiedDate = DateTime.UtcNow;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
