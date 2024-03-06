using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZPERX.Data;
using ZPERX.Models;

namespace ZPERX.Services.AirlineSightingService
{
    public class AirlineSightingService : IAirlineSightingService
    {
        private readonly DataContext _context;

        public AirlineSightingService(DataContext context)
        {
            _context = context;
        }

        public async Task<Response> Add(AirlineSighting airlineSighting)
        {
            Response response = new Response();
            response.IsSuccess = true;
            response.Message = "AirlineSighting Successfully Created";
            try
            {
                airlineSighting.CreatedDateTime = DateTime.Now;
                airlineSighting.ModifiedUserId = airlineSighting.CreatedUserId;
                _context.AirlineSightings.Add(airlineSighting);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }
            return response;
        }

        public async Task<GetAllAirlineSightingResponse> GetAll()
        {
            GetAllAirlineSightingResponse response = new GetAllAirlineSightingResponse();
            response.IsSuccess = true;
            response.Message = "Data Fetch Successfully";
            try
            {
                response.data = await _context.AirlineSightings.ToListAsync();
                if (response.data.Count == 0)
                {
                    response.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }
            return response;
        }

        public async Task<GetAllAirlineSightingResponse> GetBySearch(string search)
        {
            GetAllAirlineSightingResponse response = new GetAllAirlineSightingResponse();
            response.IsSuccess = true;
            response.Message = "Data Search Successfully";

            try
            {
                response.data = await _context.AirlineSightings
                    .Where(x => x.Name.Contains(search) || x.ShortName.Contains(search) || x.AirlineCode.Contains(search))
                    .ToListAsync();

                if (response.data == null || response.data.Count == 0)
                {
                    response.Message = "No records found matching the search criteria";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<Response> UpdateAirlineSighting(AirlineSighting request)
        {
            Response response = new Response();
            response.IsSuccess = true;
            response.Message = "Record Update Successfully By ID";

            try
            {
                if (request == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Request is null";
                    return response;
                }

                var airlineSighting = await _context.AirlineSightings.FindAsync(request.Id);
                if (airlineSighting == null)
                {
                    response.IsSuccess = false;
                    response.Message = "AirlineSighting not found";
                    return response;
                }

                airlineSighting.Name = request.Name;
                airlineSighting.ShortName = request.ShortName;
                airlineSighting.AirlineCode = request.AirlineCode;
                airlineSighting.Location = request.Location;
                airlineSighting.CreatedDateTime = request.CreatedDateTime;
                airlineSighting.IsActive = request.IsActive;
                airlineSighting.IsDeleted = request.IsDeleted;
                airlineSighting.CreatedUserId = request.CreatedUserId;
                airlineSighting.ModifiedUserId = request.ModifiedUserId;
                airlineSighting.Image = request.Image;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurred: " + ex.Message;
            }

            return response;
        }

        public async Task<Response> DeleteAirlineSighting(int id)
        {
            Response response = new Response();
            response.IsSuccess = true;
            response.Message = "AirlineSighting Delete Successfully";

            try
            {
                var airlineSighting = await _context.AirlineSightings.FindAsync(id);

                if (airlineSighting != null)
                {
                    _context.AirlineSightings.Remove(airlineSighting);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "AirlineSighting not found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs: " + ex.Message;
            }

            return response;
        }
    }
}
