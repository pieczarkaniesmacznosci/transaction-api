using System;
using System.Collections.Generic;
using System.Linq;
using Interview.Controllers;
using Interview.Models;
using Interview.Services;
using Moq;
using NUnit.Framework;

namespace Interview.Tests.Controllers
{
    [TestFixture]
    public class TransactionControllerTests
    {
        private Mock<ITransactionService> dataService;
        private TransactionController _dataController;

        [SetUp]
        public void SetUp()
        {
            this.dataService = new Mock<ITransactionService>();
            this._dataController = new TransactionController(this.dataService.Object);
        }

        [Test]
        public void Get_CalledWithoutId_ResultContainsAllElements()
        {
            // Arrange
            this.dataService.Setup(x => x.GetAllTransactions()).Returns(new List<Transaction>
            {
                new Transaction()
                {
                    Amount = 11.1,
                    ApplicationId = 222,
                    ClearedDate =null,
                    Debit = "Debit",
                    Id = "1111111",
                    IsCleared = false,
                    PostingDate = new DateTime(2020, 1, 1, 11, 11, 11),
                    Summary = "summary1"
                },
                new Transaction()
                {
                    Amount = 22.2,
                    ApplicationId = 2222,
                    ClearedDate =new DateTime(2020, 2, 2, 21, 21, 21),
                    Debit = "Debit",
                    Id = "222222",
                    IsCleared = false,
                    PostingDate = new DateTime(2020, 2, 2, 22, 22, 22),
                    Summary = "summary2"
                }
            });

            // Act
            var result = _dataController.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
            Assert.AreEqual(result.ElementAt(0).Id, "1111111");
        }

        [Test]
        public void Get_CalledWithId_ResultContainsElements()
        {
            // Arrange
            this.dataService.Setup(x => x.GetTransaction("1111111"))
                .Returns(
                new Transaction()
                {
                    Amount = 11.1,
                    ApplicationId = 222,
                    ClearedDate = null,
                    Debit = "Debit",
                    Id = "1111111",
                    IsCleared = false,
                    PostingDate = new DateTime(2020, 1, 1, 11, 11, 11),
                    Summary = "summary1"
                });

            // Act
            var result = _dataController.Get("1111111");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ApplicationId, 222);
        }

        [Test]
        public void Post_CalledWithNullArgument_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _dataController.Post(""));
        }

        [Test]
        public void Post_CalledWithInvalidArgument_ThrowsFormatException()
        {
            var objToAdd = "{\"id\" = 123213}";
            // Assert
            Assert.Throws<FormatException>(() => _dataController.Post(objToAdd));
        }

        // TODO: Similar for other methods, checking correctness of the data and returned values. 
    }
}
