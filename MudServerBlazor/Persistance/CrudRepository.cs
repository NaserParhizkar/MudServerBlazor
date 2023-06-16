using Microsoft.EntityFrameworkCore;
using MudServerBlazor.Persistance.Abstract;
using System;

namespace MudServerBlazor.Persistance
{
    public class CrudRepository<T> : ICrudRepository<T>
        where T : class
    {
        private readonly DbContext db;
        private DbSet<T> entities;

        public CrudRepository(ChinookContext context)
        {
            db = context;
            entities = context.Set<T>();
        }
        public virtual T Find<TKey>(TKey key) => entities.Find(key);
        public virtual ValueTask<T> FindAsync<TKey>(TKey key) => entities.FindAsync(key);

        public virtual List<T> GetAll() => entities.ToList();
        public virtual Task<List<T>> GetAllAsync() => entities.ToListAsync();

        public virtual void Insert(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            entities.Add(entity);
            db.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            entities.Update(entity);
            db.SaveChanges();
        }

        public virtual void Delete<TKey>(TKey key)
        {
            var entity = db.Find(typeof(T),key);
            if (entity != null) Delete(entity);
        }

        public virtual void Delete(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            entities.Remove(entity);
            db.SaveChanges();
        }

        public virtual void SaveChanges() => db.SaveChanges();
    }
}
