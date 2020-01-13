using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interview.Models;
using Newtonsoft.Json;

namespace Interview.Services
{
    public class JsonTransactionService
    {
        private List<Transaction> dataSet;

        public JsonTransactionService(string jsonContent)
        {
            try
            {
                JsonConvert.DeserializeObject<List<Transaction>>(jsonContent);
            }
            catch (Exception)
            {
                throw new Exception("Invalid json provided.");
            }
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this.dataSet;
        }

        public Transaction GetTransaction(string Id)
        {
            return new Transaction();
        }

        public void AddTransaction(Transaction transaction)
        {

        }

        public void EditTransaction(Transaction transaction)
        {

        }

        public void DeleteTransaction(string Id)
        {

        }
    }
}