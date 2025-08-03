using BuyTickets.Models;
using System.Collections.Generic;

namespace BuyTickets.Data.ViewModel
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Cinemas = new List<Cinema>();
        }
        public List<Cinema> Cinemas { get; set; }
    }
}
