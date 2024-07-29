using Newtonsoft.Json;
using OrderGenerator.Models;
using OrderGenerator.Services.Interfaces;
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
                var jsonString = await httpClient.GetStringAsync("" +
                    "");

                var response = JsonConvert.DeserializeObject<OrdersList>(jsonString);

                return response;
            }
        }

        public async Task<OrderPostResult> AddOrder(Order orderPost)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var content = new StringContent(
                    JsonConvert.SerializeObject(orderPost), 
                    Encoding.UTF8, 
                    "application/json"
                );

                var response = await httpClient.PostAsync(
                    "",
                    content
                    );

                var result = JsonConvert.DeserializeObject<OrderPostResult>(
                    await response.Content.ReadAsStringAsync()
                );

                return result;
            }
        }
    }
}
