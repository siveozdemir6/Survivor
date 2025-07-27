namespace Survivor.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        //Relational Properties

        public List<CompetitorEntity> Competitors { get; set; }

    }
}
