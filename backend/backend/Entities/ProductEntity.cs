namespace backend.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
