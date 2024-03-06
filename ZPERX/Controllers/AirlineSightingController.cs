using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZPERX.Models;
using ZPERX.Services.AirlineSightingService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZPERX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineSightingController : ControllerBase
    {
        private readonly IAirlineSightingService _airlineSightingService;

        public AirlineSightingController(IAirlineSightingService airlineSightingService)
        {
            _airlineSightingService = airlineSightingService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AirlineSighting airlineSighting)
        {
            var result = await _airlineSightingService.Add(airlineSighting);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            GetAllAirlineSightingResponse response = await _airlineSightingService.GetAll();
            return Ok(response);
        }

        [HttpGet("Get/{search}")]
        public async Task<IActionResult> GetBySearch(string search)
        {
            GetAllAirlineSightingResponse response = await _airlineSightingService.GetBySearch(search);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAirlineSighting(AirlineSighting request)
        {
            var result = await _airlineSightingService.UpdateAirlineSighting(request);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAirlineSighting(int id)
        {
            var result = await _airlineSightingService.DeleteAirlineSighting(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return NotFound(result.Message);
        }
    }
}
