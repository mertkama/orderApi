namespace WebApi.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public float PaidPrice { get; set; }
        public float Amount { get; set; }
        public string AmountType { get; set; }
        public string ProductJson { get; set; }
    }
}