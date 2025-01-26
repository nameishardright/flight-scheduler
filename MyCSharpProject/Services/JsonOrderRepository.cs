using SpeedyAir.Models;
using SpeedyAir.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SpeedyAir.Services
{
    public class JsonOrderRepository : IOrderRepository
    {
        public List<Order> LoadOrders(string filePath)
        {
            try
            {
                string projectDirectory = @"C:\Users\zihao\OneDrive\vs code\IBM\MyCSharpProject";
                string fullPath = Path.Combine(projectDirectory, filePath);

                string jsonString = File.ReadAllText(fullPath);
                var orderDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

                var orders = new List<Order>();
                foreach (var kvp in orderDict)
                {
                    orders.Add(new Order
                    {
                        OrderNumber = kvp.Key,
                        Destination = kvp.Value.GetProperty("destination").GetString()
                    });
                }
                return orders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when loading orders: {ex.Message}");
                return new List<Order>();
            }
        }
    }
} 