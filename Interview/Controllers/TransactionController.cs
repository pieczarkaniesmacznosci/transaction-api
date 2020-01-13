using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Interview.Models;

namespace Interview.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : ApiController
    {
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return new List<Transaction>();
        }

        [HttpGet]
        public Transaction Get(string Id)
        {
            return new Transaction();
        }

        [HttpPost]
        public void Post(string transaction)
        {

        }

        [HttpPut]
        public void Put(string transaction)
        {

        }
    }
}
