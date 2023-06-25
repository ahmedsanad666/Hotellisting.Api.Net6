using Microsoft.EntityFrameworkCore;
using netApiCourse.Contracts;
using netApiCourse.Data;

namespace netApiCourse.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDbContext _context;

        public GenericRepository(HotelListingDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
          await _context.AddAsync(entity);
          await _context.SaveChangesAsync();
            return entity;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exsits(int id)
        {
            
        }

        public async Task<List<T>> GetAllAsync()
        {
          return await _context.Set<T>().ToListAsync();
        }

            public async Task<T> GetAsync(int? id)
            {
               if(id is null)
                {
                    return null; 
                }

                return await _context.Set<T>().FindAsync(new object[] { id });
        }

        public async Task UpdateAsync(T entity)
        {
             _context.Update(entity);
            await _context.SaveChangesAsync();
         
        }
    }
}
