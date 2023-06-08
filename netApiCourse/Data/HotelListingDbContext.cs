using Microsoft.EntityFrameworkCore;

namespace netApiCourse.Data
{
    public class HotelListingDbContext : DbContext {


        public HotelListingDbContext(DbContextOptions options ) :base(options)
        {
             
        }


        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(

                new Country
                {
                    Id= 1,
                    Name="Egypt",
                    ShortName ="EG"
                },
                   new Country
                {
                    Id= 2,
                    Name="Istanbul",
                    ShortName ="IS"
                } ,
                new Country
                {
                    Id= 3,
                    Name="Engeland",
                    ShortName ="EN"
                }
                );

            modelBuilder.Entity<Hotel>().HasData(

                new Hotel
                {
                    Id = 1,
                    Name = "fiveStar",
                    Adress="egypt",
                    CountryId=1,
                    Rating=3.4
                },
                   new Hotel
                {
                    Id = 2,
                    Name = "firstSpot",
                    Adress="egypt",
                    CountryId=2,
                    Rating=4.1
                },
                   new Hotel
                {
                    Id = 3,
                    Name = "streetline",
                    Adress="nassus",
                    CountryId=3,
                    Rating=2.2
                }
                
                );
        }
    }
}
