using netApiCourse.DTOs.Hotel;

namespace netApiCourse.DTOs.Country;

// u don't need any validation cause they are read only
public class GetCountryDTO :BaseCountryDTO
    {
        public int Id { get; set; }
      
    }

