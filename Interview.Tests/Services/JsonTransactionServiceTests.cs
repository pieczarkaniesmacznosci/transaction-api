using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Interview.Models;
using Interview.Services;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Interview.Tests.Services
{
    [TestFixture]
    public class JsonTransactionServiceTests
    {
        private JsonTransactionService dataService;

        [SetUp]
        public void SetUp()
        {
            var jsonPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\data.json"));
            var data = JArray.Parse(File.ReadAllText(jsonPath));
            this.dataService = new JsonTransactionService(data);
        }

        [Test]
        public void GetAllTransactions_CalledOnExampleJson_ConsistAllElements()
        {
            var result = this.dataService.GetAllTransactions();

            Assert.AreEqual(result.Count(), 17);
        }

        [Test]
        public void GetTransaction_CalledWithValidId_ReturnsElement()
        {
            var result = this.dataService.GetTransaction("194f0d46-6b87-4b59-a73c-e543f035ae1a");

            Assert.AreEqual(result.ApplicationId, 197104);
        }

        [Test]
        public void GetTransaction_CalledWithInvalidId_ThrowsKeyNotFoundError()
        {
            Assert.Throws<KeyNotFoundException>(()=> this.dataService.GetTransaction("fsfs"));
        }

        [Test]
        public void EditTransaction_CalledWithValidId_EditsEntry()
        {
            var editedEntry = new Transaction()
            {
                Amount = 11.1,
                ApplicationId = 222,
                ClearedDate = null,
                Debit = "Debit",
                Id = "3f2b12b8-2a06-45b4-b057-45949279b4e5",
                IsCleared = false,
                PostingDate = new DateTime(2020, 1, 1, 11, 11, 11),
                Summary = "summary1"
            };
            // Act
            this.dataService.EditTransaction(editedEntry);

            var result = this.dataService.GetAllTransactions();
            // Assert
            Assert.AreEqual(result.ElementAt(0).ApplicationId, 222);
        }

        [Test]
        public void DeleteDataEntry_CalledWithValidId_DeletesEntry()
        {
            // Act
            this.dataService.DeleteTransaction("3f2b12b8-2a06-45b4-b057-45949279b4e5");
            var result = this.dataService.GetAllTransactions();

            // Assert
            Assert.AreEqual(result.Count(), 16);
        }

        // TODO: Similar for other methods, checking correctness of the data and returned values. 
    }
}
