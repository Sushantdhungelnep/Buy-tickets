using BuyTickets.Data.Base;
using BuyTickets.Models;

namespace BuyTickets.Data.Services
{
    public class CinemasService:EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
        }
    }
}
