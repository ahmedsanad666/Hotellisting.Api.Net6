using AutoMapper;
using netApiCourse.Data;
using netApiCourse.DTOs.Country;
using netApiCourse.DTOs.Hotel;

namespace netApiCourse.Configuration;

    public class MapperConfig : Profile
    {
    public MapperConfig() { 
    
    CreateMap<Country,CreateCountryDTO>().ReverseMap();
        CreateMap<Country,GetCountryDTO>().ReverseMap();
        CreateMap<Country,UpdateCountryDTO>().ReverseMap();
        CreateMap<Country,GetCountryDetailsDTO>().ReverseMap();

        //hotels DTOS
        CreateMap<Hotel,Hotels>().ReverseMap();
    }

    }

