using Microsoft.EntityFrameworkCore;
using Survivor.Entities;

namespace Survivor.Context
{
    public class SurvivorDbContext : DbContext
    {

        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<CompetitorEntity> Competitors { get; set; }
    }
}
