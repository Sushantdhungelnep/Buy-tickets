using BuyTickets.Data.Base;
using BuyTickets.Data.ViewModel;
using BuyTickets.Models;
using System.Threading.Tasks;

namespace BuyTickets.Data.Services
{
    public interface IMoviesService: IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsvalues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
