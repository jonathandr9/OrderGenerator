namespace OrderGenerator.Models
{
    public class Order
    {
        public AssetsList ativo { get; set; }
        public string lado { get; set; }    
        public int quantidade { get; set; }
        public decimal preco { get; set; }
    }

    public enum AssetsList
    {
        PETR4,
        VALE3,
        VIIA4
    }
}
