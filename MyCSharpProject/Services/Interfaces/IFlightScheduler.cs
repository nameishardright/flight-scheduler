using SpeedyAir.Models;

namespace SpeedyAir.Services.Interfaces
{
    public interface IFlightScheduler
    {
        IReadOnlyList<Flight> Flights { get; }
        void LoadDefaultSchedule();
    }
} 