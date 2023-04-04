using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BulkBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BulkBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            //_context.Products.Include(u => u.Category).Include(u => u.CoverType);
            this.dbSet = _context.Set<T>();

        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProperties=null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
				query = query.Where(filter);
			}
            
            if (includeProperties != null)
            {
                foreach(var includeProp in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            

            return query.ToList();

        }

		/// <summary>
		/// t is the model, getfirstordefault is the name of the method which returns a single model or null.
		/// 
		/// </summary>
		/// <param name="filter">the brackets are to define the method, the filter is the set of conditions
		/// to compare against the model of type t. expression allows me to parse in a strongly typed 
		/// expression (alys gonna send me a link). the angle brackets are what allows me to define generics. 
		/// func is a type that defines a function, it must have an output type, in this case bool. and
		/// t is the model. a function is like a method == function. 
		/// saying </param>
		/// <param name="includeProperties">includeProperties allows me to access
		/// different tables through foreign keys. </param>
		/// <param name="tracked">allows entity framework to track.</param>
		/// <returns></returns>
		public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            /* iqueryable creates a queryable so i can query the dbset of t. 
             * that equal*/
            IQueryable<T> query = dbSet;

            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            /* using linq expression.Where(calling the filter from above to pass in) */
            query = query.Where(filter);
            if(includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }

                
            }

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
