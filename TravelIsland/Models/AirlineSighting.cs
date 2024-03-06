using System.ComponentModel.DataAnnotations;

namespace TravelIsland.Models
{
    public class AirlineSighting
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(5)]
        public string ShortName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]{3}-\d{4}$")]
        public string AirlineCode { get; set; }
        [Required]
        [MaxLength(200)]
        public string Location { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        [Required]
        public int CreatedUserId { get; set; }
        [Required]
        public int ModifiedUserId { get; set; }
        public string Image { get; set; }
    }

        public class GetAllAirlineSightingResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<AirlineSighting>? data { get; set; }

    }

}
