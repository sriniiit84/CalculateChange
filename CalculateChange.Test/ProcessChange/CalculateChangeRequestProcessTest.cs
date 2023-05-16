using CalculateChange.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CalculateChange.ProcessChange
{
    [TestFixture]
    public class CalculateChangeRequestProcessTest
    {
        private CaculateRequestProcess _processObj;

        public CalculateChangeRequestProcessTest()
        {
            _processObj = new CaculateRequestProcess();
        }

        [Test]
        public void ProcessChange_CalculatgeChangeWithInteger_ReturnsCorrectChange()
        {
            //Arange
            var request = new CalculateChangeRequest
            {
                GivenAmount = 50,
                ProductPrice = 30
            };

            //Act
            CalculateChangeResult result = _processObj.ProcessChange(request);

            // Assert
            var expectedChange = new Dictionary<string, int>()
            {
                { "£20", 1 }
            };
            CollectionAssert.AreEqual(expectedChange, result.ChangeDenominations);
        }


        [Test]
        public void ProcessChange_CalculatgeChangeWithDecimal_ReturnsCorrectChange()
        {
            var request = new CalculateChangeRequest
            {
                GivenAmount = 20,
                ProductPrice = 5.50m
            };

            CalculateChangeResult result = _processObj.ProcessChange(request);

            var expectedChange = new Dictionary<string, int>()
            {
                {"£10", 1 },
                {"£2",2 },
                {"50.0p",1 }
            };
            CollectionAssert.AreEqual(expectedChange, result.ChangeDenominations);
        }



        [Test]
        public void ProcessChange_CalculatgeChange_ReturnsNoChange()
        {
            var request = new CalculateChangeRequest
            {
                GivenAmount = 20,
                ProductPrice = 20
            };

            CalculateChangeResult result = _processObj.ProcessChange(request);

            Assert.IsEmpty(result.ChangeDenominations);
        }


        [Test]
        public void ProcessChange_ThrowsException_WhenInsufficientAmount()
        {
            var request = new CalculateChangeRequest
            {
                GivenAmount = 20,
                ProductPrice = 40
            };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _processObj.ProcessChange(request));
        }
    }
}
