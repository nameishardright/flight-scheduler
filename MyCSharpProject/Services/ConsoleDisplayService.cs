using System;
using System.Collections.Generic;
using SpeedyAir.Models;
using SpeedyAir.Services.Interfaces;

public class ConsoleDisplayService : IDisplayService
{
    public void DisplayFlightSchedule(IEnumerable<Flight> flights)
    {
        Console.WriteLine("Flight Schedule:");
        foreach (var flight in flights)
        {
            Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.DepartureCity}, " +
                $"arrival: {flight.ArrivalCity}, day: {flight.Day}");
        }
    }

    public void DisplayOrderItineraries(IEnumerable<(string OrderNumber, Flight Flight)> scheduledOrders, 
                                      IEnumerable<string> unscheduledOrders)
    {
        Console.WriteLine("\nOrder Itineraries:");
        foreach (var (orderNumber, flight) in scheduledOrders)
        {
            Console.WriteLine($"order: {orderNumber}, flightNumber: {flight.FlightNumber}, " +
                $"departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.Day}");
        }

        foreach (var orderNumber in unscheduledOrders)
        {
            Console.WriteLine($"order: {orderNumber}, flightNumber: not scheduled");
        }
    }

  
} 