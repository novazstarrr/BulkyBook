using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null,bool tracked = true);
        /*we used irepository for the method signature which can be implemented later on. T is the table(class),
        The getfirstordefault is the method name. Im saying im gonna be using an experession which means
        ill be using a filter(the name above), expression which will allow me to compare records (row/s), against 
        the filter and return the first or null. so we define this in an interface so we can use IOC and implement
        generic methods for accessing data. */
        
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

        
    }
}
