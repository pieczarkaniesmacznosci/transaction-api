using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interview.Models;
using Newtonsoft.Json;

namespace Interview.Services
{
    public class JsonTransactionService : ITransactionService
    {
        private List<Transaction> dataSet;

        public JsonTransactionService(string jsonContent)
        {
            try
            {
                this.dataSet = JsonConvert.DeserializeObject<List<Transaction>>(jsonContent);
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

        public Transaction GetTransaction(string id)
        {
            return this.dataSet.SingleOrDefault(t => t.Id == id);
        }

        public void AddTransaction(Transaction transaction)
        {
            this.dataSet.Add(transaction);
        }

        public void EditTransaction(Transaction transaction)
        {
            var transactionToEdit = this.dataSet.SingleOrDefault(t => t.Id == transaction.Id);

            transactionToEdit.Id = transaction.Id;
            transactionToEdit.ApplicationId = transaction.ApplicationId;
            transactionToEdit.Amount = transaction.Amount;
            transactionToEdit.Debit = transaction.Debit;
            transactionToEdit.IsCleared = transaction.IsCleared;
            transactionToEdit.PostingDate = transaction.PostingDate;
            transactionToEdit.ClearedDate = transaction.ClearedDate;
            transactionToEdit.Summary = transaction.Summary;
        }

        public void DeleteTransaction(string id)
        {
            this.dataSet.Remove(this.dataSet.SingleOrDefault(t=>t.Id == id));
        }
    }
}