using System.Collections.Generic;
using Interview.Models;

namespace Interview.Services
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransaction(string Id);
        void AddTransaction(Transaction transaction);
        void EditTransaction(Transaction transaction);
        void DeleteTransaction(string id);
    }
}