using System;

namespace TicketBookingApplication.Models
{
    public class SearchViewModel
    {
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        DateTime Date { get; set; }
    }
}