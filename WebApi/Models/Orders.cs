using System;

namespace WebApi.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemCount { get; set; }
        public float TotalPrice { get; set; }
        public float PaidPrice { get; set; }
        public float DiscountedPrice { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        
    }
}