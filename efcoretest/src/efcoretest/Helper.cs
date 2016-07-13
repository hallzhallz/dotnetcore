using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;

namespace efcoretest
{
    public class Helper
    {
        private BloggingContext _context;

        public Helper(BloggingContext context) {
            _context = context;
        }

        private static IQueryable<EntityType> TestFilter<EntityType>(IQueryable<EntityType> q) where EntityType : class, IId
        {
            return q.Where(x => x.Id > 0);
        }

        public List<Post> GetList(string param) {
            return TestFilter(_context.Posts).AsNoTracking()
                                                  .Where(x => x.Blog.Id > 1)
                                                  .Include(x => x.Blog)
                                                  .ToList();
        }

    }
    
}
