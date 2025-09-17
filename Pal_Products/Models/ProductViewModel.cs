namespace Pal_Products.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }
        public int Qty { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
    }
}
