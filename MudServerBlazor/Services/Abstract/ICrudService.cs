namespace MudServerBlazor.Services.Abstract
{
    public interface ICrudService<T> where T : class
    {
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete<TKey>(TKey key);
        void SaveChanges();
    }
}
