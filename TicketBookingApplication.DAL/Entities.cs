using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBookingApplication.DAL
{
    public class Profile
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int FlightId { get; set; }
        public int ComfortId { get; set; }
        public int ProfileId { get; set; }
        public decimal Price { get; set; }
        public int SeatNumber { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Comfort Comfort { get; set; }
    }

    public class Flight
    {
        public int Id { get; set; }
        public int AirplaneId { get; set; }
        public int ArrivalCityId { get; set; }
        public int DepartureCityId { get; set; }
        public DateTime ArivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        [ForeignKey("ArrivalCityId")]
        public virtual City ArrivalCity { get; set; }

        [ForeignKey("DepartureCityId")]
        public virtual City DepartureCity { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostIndex { get; set; }

        [InverseProperty("ArrivalCity")]
        public virtual ICollection<Flight> FlightsAsArrival { get; set; }

        [InverseProperty("DepartureCity")]
        public virtual ICollection<Flight> FligtsAsDeparture { get; set; }
    }

    public class Airplane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }

    public class Comfort
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
