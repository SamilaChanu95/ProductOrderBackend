namespace ProductOrderBackend.Model
{
    public class ProductOrder
    {
        public int OrderNo { get; set; }
        public int Quantity { get; set; }
        public string? ProductCode { get; set; }
        public string? CustomerCode { get; set; }

    }
}
