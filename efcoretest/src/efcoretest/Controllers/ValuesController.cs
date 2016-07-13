using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Models;
using efcoretest;
using Microsoft.EntityFrameworkCore;


namespace efcoretest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        BloggingContext _context;

        public ValuesController(BloggingContext context) {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<Post> Get([FromQuery] string param = "")
        {
            Helper h = new Helper(_context);

            List<Post> views = h.GetList(param);

            return views.OrderBy(x => x.Id)
                        .Skip(1)
                        .Take(999)
                        .ToList();
        }


        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

   
}
