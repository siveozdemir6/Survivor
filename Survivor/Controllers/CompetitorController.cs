using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survivor.Context;
using Survivor.Entities;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly SurvivorDbContext _context;
        public CompetitorController(SurvivorDbContext context)
        {
            _context = context;
        }
        // GET: api/Competitor
        [HttpGet]
        public IActionResult GetCompetitors()
        {
            var competitors = _context.Competitors
                .Where(c => !c.IsDeleted)
                .ToList();
            return Ok(competitors);
        }
        // GET: api/Competitor/5
        [HttpGet("{id}")]
        public IActionResult GetCompetitor(int id)
        {
            var competitor = _context.Competitors
                .FirstOrDefault(c => c.Id == id && !c.IsDeleted);
            if (competitor == null)
            {
                return NotFound();
            }
            return Ok(competitor);
        }

        //GET: api/Competitor/category/5
        [HttpGet("category/{categoryId}")]
        public IActionResult GetCompetitorsByCategory(int categoryId)
        {
            var competitors = _context.Competitors
                .Where(c => c.CategoryId == categoryId && !c.IsDeleted)
                .ToList();
            if (competitors.Count == 0)
            {
                return NotFound();
            }
            return Ok(competitors);
        }
        // POST: api/Competitor
        [HttpPost]
        public IActionResult CreateCompetitor([FromBody] CompetitorEntity competitor)
        {
            if (competitor == null || string.IsNullOrWhiteSpace(competitor.FirstName) || string.IsNullOrWhiteSpace(competitor.LastName))
            {
                return BadRequest("Invalid competitor data.");
            }
            _context.Competitors.Add(competitor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCompetitor), new { id = competitor.Id }, competitor);
        }
        // PUT: api/Competitor/5
        [HttpPut("{id}")]
        public IActionResult UpdateCompetitor(int id, [FromBody] CompetitorEntity competitor)
        {
            if (competitor == null || string.IsNullOrWhiteSpace(competitor.FirstName) || string.IsNullOrWhiteSpace(competitor.LastName))
            {
                return BadRequest("Invalid competitor data.");
            }

            var existingCompetitor = _context.Competitors.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
            if (existingCompetitor == null)
            {
                return NotFound();
            }
            existingCompetitor.FirstName = competitor.FirstName;
            existingCompetitor.LastName = competitor.LastName;
            existingCompetitor.CategoryId = competitor.CategoryId;

            _context.SaveChanges();
            return NoContent();
        }
        // DELETE: api/Competitor/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompetitor(int id)
        {
            var competitor = _context.Competitors.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
            if (competitor == null)
            {
                return NotFound();
            }
            competitor.IsDeleted = true;
            competitor.ModifiedDate = DateTime.UtcNow;
            _context.SaveChanges();
            return NoContent();

        }
    }
}
