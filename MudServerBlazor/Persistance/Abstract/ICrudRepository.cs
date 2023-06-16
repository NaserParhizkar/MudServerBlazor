using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MudServerBlazor.Persistance.Abstract
{
    public interface ICrudRepository<T> where T : class 
    {
        T Find<TKey>(TKey key);
        ValueTask<T> FindAsync<TKey>(TKey key);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete<TKey>(TKey key);
        void SaveChanges();
    }
}
