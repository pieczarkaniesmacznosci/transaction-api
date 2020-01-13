using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Interview.Models;
using Interview.Services;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace Interview.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : ApiController
    {
        private ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return this.transactionService.GetAllTransactions();
        }

        [HttpGet]
        [Route("{id}")]
        public Transaction Get(string id)
        {
            if (id.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Id not provided");
            }

            return this.transactionService.GetTransaction(id);
        }

        [HttpPost]
        public void Post([FromBody] string transaction)
        {
            if (transaction.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Object to add not provided");
            }

            Transaction addedTransaction;

            try
            {
                addedTransaction = JsonConvert.DeserializeObject<Transaction>(transaction);
            }
            catch (JsonReaderException)
            {
                throw new FormatException($"Provided data not representing Data object: {transaction}");
            }

            this.transactionService.AddTransaction(addedTransaction);
        }

        [HttpPut]
        public void Put([FromBody]string transaction)
        {
            if (transaction.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Object to add not provided");
            }

            Transaction addedTransaction;

            try
            {
                addedTransaction = JsonConvert.DeserializeObject<Transaction>(transaction);
            }
            catch (JsonReaderException)
            {
                throw new FormatException($"Provided data not representing Data object: {transaction}");
            }

            this.transactionService.EditTransaction(addedTransaction);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(string id)
        {
            if (id.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Id not provided");
            }

            this.transactionService.DeleteTransaction(id);
        }
    }
}
