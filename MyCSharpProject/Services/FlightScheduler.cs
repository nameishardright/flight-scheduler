using System;
using System.Collections.Generic;
using SpeedyAir.Models;

namespace SpeedyAir.Services
{
    public class FlightScheduler
    {
        private List<Flight> _flights = new List<Flight>();

        public IReadOnlyList<Flight> GetFlights()
        {
            return _flights.AsReadOnly();
        }

        public void LoadDefaultSchedule()
        {
            // Day 1 
            AddFlight(1, "YUL", "YYZ", 1);
            AddFlight(2, "YUL", "YYC", 1);
            AddFlight(3, "YUL", "YVR", 1);

            // Day 2 
            AddFlight(4, "YUL", "YYZ", 2);
            AddFlight(5, "YUL", "YYC", 2);
            AddFlight(6, "YUL", "YVR", 2);
        }

        private void AddFlight(int flightNumber, string departure, string arrival, int day)
        {
            _flights.Add(new Flight
            {
                FlightNumber = flightNumber,
                DepartureCity = departure,
                ArrivalCity = arrival,
                Day = day,
                Capacity = 20,
                BoxesLoaded = 0
            });
        }

    }
} 