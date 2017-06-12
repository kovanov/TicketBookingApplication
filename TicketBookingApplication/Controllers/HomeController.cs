using System.Web.Mvc;
using TicketBookingApplication.BL.Services;
using TicketBookingApplication.Models;

namespace TicketBookingApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly AirportService _airportService = new AirportService();

        public ActionResult Index()
        {
            var cities = _airportService.Cities;
            return View(cities);
        }

        public ActionResult Search()
        {
            if (model == null)
            {
                
            }
            return null;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}