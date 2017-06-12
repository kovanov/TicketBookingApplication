using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketBookingApplication.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage ="Откуда летим?"), Display(Name = "Город отправления")]
        public int DepartureCityId { get; set; }

        [Required(ErrorMessage = "Куда летим?"), Display(Name = "Город прибытия")]
        public int ArrivalCityId { get; set; }

        [Required(ErrorMessage = "Когда летим?"), Display(Name = "Дата отправки"), DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        public string OrderField { get; set; }
        public string OrderDirection { get; set; }
    }
}