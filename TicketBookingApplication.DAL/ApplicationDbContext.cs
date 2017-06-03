using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingApplication.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("name=AirportDb") { }

        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Comfort> Comforts { get; set; }
        public virtual DbSet<Airplane> Airplanes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
