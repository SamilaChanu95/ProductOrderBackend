namespace ProductOrderBackend.Model
{
    public class Product
    {
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public double Discount { get; set; }
        public double UnitPrice { get; set; }
    }
}
