namespace Survivor.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
