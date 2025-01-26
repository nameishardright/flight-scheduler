using System;
using System.Collections.Generic;
using SpeedyAir.Models;

namespace SpeedyAir.Services
{
    public class OrderScheduler
    {
        private readonly FlightScheduler _flightScheduler;
        private readonly Dictionary<string, Flight> _orderAssignments = new Dictionary<string, Flight>();
        private readonly List<Order> _unscheduledOrders = new List<Order>();

        public OrderScheduler(FlightScheduler flightScheduler)
        {
            _flightScheduler = flightScheduler;
        }

        public void ScheduleOrders(List<Order>? orders)
        {
            if (orders == null) return;
            
            foreach (var order in orders)
            {
                var assignedFlight = FindAvailableFlight(order.Destination);
                if (assignedFlight != null)
                {
                    assignedFlight.BoxesLoaded++;
                    _orderAssignments[order.OrderNumber] = assignedFlight;
                }
                else
                {
                    _unscheduledOrders.Add(order);
                }
            }
        }

        private Flight FindAvailableFlight(string destination)
        {
            foreach (var flight in _flightScheduler.GetFlights())
            {
                if (flight.ArrivalCity == destination && flight.HasCapacity)
                {
                    return flight;
                }
            }
            return null;
        }

        public void DisplayItineraries()
        {
            foreach (var assignment in _orderAssignments)
            {
                var flight = assignment.Value;
                Console.WriteLine($"order: {assignment.Key}, flightNumber: {flight.FlightNumber}, " +
                    $"departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.Day}");
            }

            // Display unscheduled orders
            var unscheduledOrders = _unscheduledOrders.Select(o => o.OrderNumber);
            foreach (var orderNumber in unscheduledOrders)
            {
                Console.WriteLine($"order: {orderNumber}, flightNumber: not scheduled");
            }
        }

        public IEnumerable<(string OrderNumber, Flight Flight)> GetScheduledOrders()
        {
            return _orderAssignments.Select(kvp => (kvp.Key, kvp.Value));
        }

        public IEnumerable<string> GetUnscheduledOrders()
        {
            return _unscheduledOrders.Select(order => order.OrderNumber);
        }
    }
} 