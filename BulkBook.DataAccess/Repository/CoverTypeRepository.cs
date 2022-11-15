using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess;
using BulkyBook.Models;

namespace BulkBook.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _context;

        public CoverTypeRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

        public void Update(CoverType obj)
        {
            _context.CoverTypes.Update(obj);
        }
    }
}
