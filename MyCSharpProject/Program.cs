// filepath: /C:/Users/zihao/OneDrive/vs code/IBM/Rest hackrank.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using SpeedyAir.Services;
using SpeedyAir.Models;

namespace SpeedyAir
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var displayService = new ConsoleDisplayService();
                var orderRepository = new JsonOrderRepository();
                var flightScheduler = new FlightScheduler();
                var orderScheduler = new OrderScheduler(flightScheduler);

                // User Story #1
                flightScheduler.LoadDefaultSchedule();
                displayService.DisplayFlightSchedule(flightScheduler.GetFlights());

                // User Story #2
                List<Order> orders = orderRepository.LoadOrders("coding-assigment-orders.json");
                orderScheduler.ScheduleOrders(orders);
                
                var scheduledOrders = orderScheduler.GetScheduledOrders();
                var unscheduledOrders = orderScheduler.GetUnscheduledOrders();
                displayService.DisplayOrderItineraries(scheduledOrders, unscheduledOrders);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }
    }
}