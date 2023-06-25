
using netApiCourse.DTOs.Hotel;

namespace netApiCourse.DTOs.Country;
public class GetCountryDetailsDTO:BaseCountryDTO
    {
        public int Id { get; set; }
     

    public List<Hotels> Hotels { get; set; }


}

