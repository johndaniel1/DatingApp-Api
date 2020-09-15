using DatingApp.Data;
using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace DatingApp.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly DataContext _context;
        public ValuesController()
        {
            _context = new DataContext();
        }
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        public IHttpActionResult GetValues()
        {
            List<Values> values = _context.Values.ToList();
            return Ok(values);
            
        }

        // GET api/values/5
        public IHttpActionResult GetValue(int id)
        {
            Values value = _context.Values.FirstOrDefault(x => x.Id == id);
            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
