using OrderGenerator.Models;

namespace OrderGenerator.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrdersList> GetOrders();
        Task<OrderPostResult> AddOrder(Order orderPost);
    }
}
