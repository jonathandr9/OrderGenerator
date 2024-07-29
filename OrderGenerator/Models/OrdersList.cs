namespace OrderGenerator.Models
{
    public class OrdersListItem
    {
        public string ativo { get; set; }
        public string lado { get; set; }
        public int quantidade { get; set; }
        public double preco { get; set; }
        public string data { get; set; }
    }

    public class OrdersList
    {
        public bool sucesso { get; set; }
        public object msg_erro { get; set; }
        public List<OrdersListItem> ordens { get; set; }
    }
}
