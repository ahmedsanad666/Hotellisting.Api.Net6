using System.Diagnostics.Metrics;

namespace netApiCourse.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        // task<t> will return data (t)
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task Delete(int id);
        Task UpdateAsync(T entity);
        Task<bool> Exsits(int id);

    }
}
