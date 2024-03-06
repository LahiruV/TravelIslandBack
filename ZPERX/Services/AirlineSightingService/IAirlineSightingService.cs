using System.Threading.Tasks;
using ZPERX.Models;

namespace ZPERX.Services.AirlineSightingService
{
    public interface IAirlineSightingService
    {
        Task<Response> Add(AirlineSighting airlineSighting);
        Task<GetAllAirlineSightingResponse> GetAll();
        Task<GetAllAirlineSightingResponse> GetBySearch(string search);
        Task<Response> UpdateAirlineSighting(AirlineSighting request);
        Task<Response> DeleteAirlineSighting(int id);
    }
}
