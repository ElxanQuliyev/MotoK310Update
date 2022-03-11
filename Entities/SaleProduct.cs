namespace Entities
{
    public class SaleProduct:BaseEntity
    {
        public bool IsEnable { get; set; }
        public DateTime Deadline { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }

}
