using System;
using System.Collections.Generic;
using System.Linq;
using Interview.Models;
using Newtonsoft.Json.Linq;

namespace Interview.Services
{
    public class JsonTransactionService : ITransactionService
    {
        private List<Transaction> dataSet;

        public JsonTransactionService(JArray jsonContent)
        {
            try
            {
                this.dataSet = jsonContent.ToObject<List<Transaction>>();
            }
            catch (Exception)
            {
                throw new Exception("Invalid json provided.");
            }
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            if (this.dataSet.Count == 0)
            {
                throw new KeyNotFoundException($"No transaction data");
            }
            return this.dataSet;
        }

        public Transaction GetTransaction(string id)
        {
            var fetchedTransaction = this.dataSet.SingleOrDefault(t => t.Id == id);

            if (fetchedTransaction == null)
            {
                throw new KeyNotFoundException($"Data entry not found: {id}");
            }
            return this.dataSet.SingleOrDefault(t => t.Id == id);
        }

        public void AddTransaction(Transaction transaction)
        {
            transaction.Id = null;
            transaction.Id = Guid.NewGuid().ToString();

            this.dataSet.Add(transaction);
        }

        public void EditTransaction(Transaction transaction)
        {
            var transactionToEdit = this.dataSet.SingleOrDefault(t => t.Id == transaction.Id);

            if (transactionToEdit == null)
            {
                throw new KeyNotFoundException($"Data entry not found");
            }

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
            var transactionToDelete = this.dataSet.SingleOrDefault(t => t.Id == id);

            if (transactionToDelete == null)
            { 
                throw new KeyNotFoundException($"Data entry not found: {id}");
            }

            this.dataSet.Remove(transactionToDelete);
        }
    }
}