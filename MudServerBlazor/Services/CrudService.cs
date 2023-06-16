using Microsoft.EntityFrameworkCore;
using MudServerBlazor.Persistance.Abstract;
using MudServerBlazor.Services.Abstract;
using System;

namespace MudServerBlazor.Services
{
    public class CrudService<T> : ICrudService<T>
        where T : class
    {
        private ICrudRepository<T> repository;

        public CrudService(ICrudRepository<T> crudRepository) => repository = crudRepository;

        public virtual List<T> GetAll() => repository.GetAll();
        public virtual Task<List<T>> GetAllAsync() => repository.GetAllAsync();

        public virtual void Insert(T entity) => repository.Insert(entity);

        public virtual void Update(T entity) => repository.Update(entity);

        public virtual void Delete(T entity) => repository.Delete(entity);
        public virtual void Delete<TKey>(TKey key) => repository.Delete(key);

        public virtual void SaveChanges() => repository.SaveChanges();
    }
}
