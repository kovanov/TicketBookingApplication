namespace TicketBookingApplication.DAL.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public decimal Price { get; set; }
        public int SeatNumber { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Comfort Comfort { get; set; }
    }
}
