using Newtonsoft.Json;
using OrderGenerator.Models;
using OrderGenerator.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace OrderGenerator.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<OrdersList> GetOrders()
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var jsonString = await httpClient.GetStringAsync(
                    "http://orderaccumulator.us-east-1.elasticbeanstalk.com/Order");

                var response = JsonConvert.DeserializeObject<OrdersList>(jsonString);

                return response;
            }
        }

        public async Task<OrderPostResult> AddOrder(Order orderPost)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                
                var stringJson = JsonConvert.SerializeObject(
                    new
                    {
                        ativo = orderPost.ativo.ToString(),
                        lado = orderPost.lado,
                        quantidade = orderPost.quantidade,
                        preco = orderPost.preco
                    }
                );

                using StringContent jsonContent = new(
                   stringJson,
                   Encoding.UTF8,
                   "application/json");

                var response = await httpClient.PostAsync(
                    "http://orderaccumulator.us-east-1.elasticbeanstalk.com/Order/exposicao-financeira",
                    jsonContent
                    );

                var result = JsonConvert.DeserializeObject<OrderPostResult>(
                    await response.Content.ReadAsStringAsync()
                );

                return result;
            }
        }
    }
}
