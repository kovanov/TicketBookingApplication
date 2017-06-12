using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketBookingApplication.DAL.Domain;

namespace TicketBookingApplication.Models
{
    public class ListInfoHomeViewModel
    {
        public IEnumerable<City> Cities { get; set; }

    }
}