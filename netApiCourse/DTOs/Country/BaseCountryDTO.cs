using System.ComponentModel.DataAnnotations;

namespace netApiCourse.DTOs.Country
{
    public class BaseCountryDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
    }
}
