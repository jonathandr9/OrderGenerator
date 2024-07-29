namespace OrderGenerator.Models
{
    public class Order
    {
        public AssetsList Asset { get; set; }
        public string Side { get; set; }    
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public enum AssetsList
    {
        PETR4,
        VALE3,
        VIIA4
    }
}
