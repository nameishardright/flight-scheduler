using SpeedyAir.Models;

namespace SpeedyAir.Services.Interfaces
{
    public interface IDisplayService
    {
        void DisplayFlightSchedule(IEnumerable<Flight> flights);
        void DisplayOrderItineraries(IEnumerable<(string OrderNumber, Flight Flight)> scheduledOrders, 
                                   IEnumerable<string> unscheduledOrders);
    }
} 