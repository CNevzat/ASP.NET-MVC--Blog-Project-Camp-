using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class // T must be a class.
    {
        Context c = new Context();
        DbSet<T> _object; // _object keeps class
        public GenericRepository()
        {
            _object = c.Set<T>(); // T value sent based on context. The entity which comes from outside.
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State= EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //SingleOrDefault method returns single value.
                                                    //List method returns 1 or more values.
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); // returns list. 
        }
        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State= EntityState.Added;
            c.SaveChanges();
        }
        public List<T> List()
        {
            return _object.ToList();
        }
        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
