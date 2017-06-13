using System;
using System.Collections.Generic;
using System.Linq;
using TicketBookingApplication.DAL;
using TicketBookingApplication.DAL.Domain;

namespace TicketBookingApplication.BL.Services
{
    public class AirportService
    {
        private readonly UnitOfWork _uow = new UnitOfWork();
        public List<City> Cities
        {
            get => _uow.CityRepository.AllEntities.ToList();
        }

        public ICollection<Flight> FindFlights(int departureCityId, int arrivalCityId, DateTime departureDate)
        {
            var thisDay = departureDate.Date;
            var nextDay = thisDay.AddDays(1);
            var flights = from flight in _uow.FlightRepository.AllEntities
                          where flight.DepartureCityId == departureCityId &&
                                flight.ArrivalCityId == arrivalCityId &&
                                flight.DepartureTime >= thisDay &&
                                flight.DepartureTime < nextDay
                          select new
                          {
                              Id = flight.Id,
                              Airplane = flight.Airplane,
                              ArivalTime = flight.ArivalTime,
                              DepartureCity = flight.DepartureCity,
                              ArrivalCity = flight.ArrivalCity,
                              DepartureTime = flight.DepartureTime
                          };

            return flights.ToList().Select(x=>new Flight
            {
                Id = x.Id,
                Airplane = x.Airplane,
                ArivalTime = x.ArivalTime,
                DepartureCity = x.DepartureCity,
                ArrivalCity = x.ArrivalCity,
                DepartureTime = x.DepartureTime
            }).ToList();
        }
    }
}
