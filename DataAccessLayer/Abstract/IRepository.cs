using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository <T> // T --> type. T might be category table or writer table (entity). 
    {
        List<T> List();
        void Insert(T p); // p --> parameter 
        void Update(T p);   
        void Delete(T p);
        List<T> List(Expression<Func<T, bool>> filter); //conditional listing
        T Get(Expression<Func<T, bool>>filter); //Get methods with T type (T means entity)
    }
}
