using SpeedyAir.Models;

namespace SpeedyAir.Services.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadOrders(string filePath);
    }
} 