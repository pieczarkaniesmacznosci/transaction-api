using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Interview.Models;
using Microsoft.Ajax.Utilities;

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
        [Route("{id}")]
        public Transaction Get(string id)
        {
            if (id.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Id not provided");
            }

            return new Transaction();
        }

        [HttpPost]
        public void Post([FromBody] string transaction)
        {
            if (transaction.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Object to add not provided");
            }

        }

        [HttpPut]
        public void Put([FromBody]string transaction)
        {
            if (transaction.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Object to add not provided");
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(string id)
        {
            if (id.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Id not provided");
            }

        }
    }
}
