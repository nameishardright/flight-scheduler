namespace SpeedyAir.Models
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public required string DepartureCity { get; set; }
        public required string ArrivalCity { get; set; }
        public int Day { get; set; }
        public int Capacity { get; set; }
        public int BoxesLoaded { get; set; }

        public bool HasCapacity => BoxesLoaded < Capacity;
    }
} 