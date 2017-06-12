using System.Collections.Generic;
using System.Linq;
using TicketBookingApplication.BL.Model;
using TicketBookingApplication.DAL;

namespace TicketBookingApplication.BL.Services
{
    public class AirportService
    {
        private readonly UnitOfWork _uow = new UnitOfWork();
        public List<CityDTO> Cities
        {
            get => _uow.CityRepository.AllEntities
                .Select(x => new CityDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    PostIndex = x.PostIndex
                }).ToList();
        }
    }
}
