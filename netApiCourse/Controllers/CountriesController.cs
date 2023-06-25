 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netApiCourse.Data;
using netApiCourse.DTOs;
using netApiCourse.DTOs.Country;

namespace netApiCourse.Controllers
{
    [Route("Test/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        // injecting dbcontext to controller 
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;
        public CountriesController(HotelListingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDTO>>> GetCountries()
        {
          var countries =  await _context.Countries.ToListAsync();
              var records = _mapper.Map<List<GetCountryDTO>>(countries);  
        return Ok(records);
        
        }


        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDetailsDTO>> GetCountry(int id)
        {
            var country = await _context.Countries.Include(u => u.Hotels).FirstOrDefaultAsync(u => u.Id == id); ;
            // converting to dto
            if (country == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<GetCountryDetailsDTO>(country);

            return Ok(record);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDTO updateCountryDTO)
        {
            if (id != updateCountryDTO.Id)
            {
                return BadRequest();
            }

            //_context.Entry(country).State = EntityState.Modified;
            //_context.Update(country);
            var country = await _context.Countries.FindAsync(id);
            if(country == null) {
                return NotFound();

            }
            _mapper.Map(updateCountryDTO, country);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDTO countryDTO)
        {

           

            var country  =_mapper.Map<Country>(countryDTO);

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
