using TicketBookingApplication.DAL.Repositories;

namespace TicketBookingApplication.DAL
{
    public class UnitOfWork
    {
        private static ApplicationDbContext _context = new ApplicationDbContext();

        public AirplaneRepository AirplaneRepository { get; } = new AirplaneRepository(_context);
        public CityRepository CityRepository { get; } = new CityRepository(_context);
        public ComfortRepository ComfortRepository { get; } = new ComfortRepository(_context);
        public FlightRepository FlightRepository { get; } = new FlightRepository(_context);
        public OrderRepository OrderRepository { get; } = new OrderRepository(_context);
        public ProfileRepository ProfileRepository { get; } = new ProfileRepository(_context);
        public TicketRepository TicketRepository { get; } = new TicketRepository(_context);
        public UserRepository UserRepository { get; } = new UserRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
