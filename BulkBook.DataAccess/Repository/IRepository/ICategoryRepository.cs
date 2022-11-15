﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyBook.Models;

namespace BulkBook.DataAccess.Repository.IRepository
{
    //why do we save here? is it to abstract more?
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        
    }
}
