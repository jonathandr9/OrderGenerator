namespace OrderGenerator.Models
{
    public class OrderPostResult
    {
        public bool sucesso { get; set; }
        public decimal? exposicao_atual { get; set; }
        public string msg_erro { get; set; }
    }
}
