using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ContosoUniversity.DAL
{
    public class Repository<T> where T : class
    {
        private readonly SchoolContext _context;

        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            _context = new SchoolContext();
            DbSet = _context.Set<T>();
        }

        public Repository(SchoolContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void SetModifiedState(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}