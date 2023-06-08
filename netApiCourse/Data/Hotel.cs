using System.ComponentModel.DataAnnotations.Schema;

namespace netApiCourse.Data
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public Double Rating { get; set; }

        // FK
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
