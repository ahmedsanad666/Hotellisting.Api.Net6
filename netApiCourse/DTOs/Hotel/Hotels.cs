

namespace netApiCourse.DTOs.Hotel {


    public class Hotels
    {
        // these data would be read only so u dont need validation

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public Double Rating { get; set; }

        // FK

        public int CountryId { get; set; }


    }




}
