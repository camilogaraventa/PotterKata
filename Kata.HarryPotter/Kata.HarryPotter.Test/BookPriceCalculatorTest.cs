using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.HarryPotter.Test
{
    /// <summary>
    /// Summary description for BookPriceCalculatorTest
    /// </summary>
    [TestClass]
    public class BookPriceCalculatorTest
    {
        [TestMethod]
        public void ZeroBooks_CostsZero()
        {
            List<Int32> books = this.GenerateBooksList();

            Decimal cost = BookPriceCalculator.Calculate(books);

            Assert.AreEqual(0, cost);

        }

        [TestMethod]
        public void OneBook_CostsEight()
        {
            List<Int32> books = this.GenerateBooksList(1);

            Decimal cost = BookPriceCalculator.Calculate(books);

            Assert.AreEqual(8, cost);
        }
     
        private List<Int32> GenerateBooksList(params Int32[] books)
        {
            List<Int32> booksList = new List<Int32>();

            foreach(Int32 book in books)
            {
                booksList.Add(book);
            }

            return booksList;
        }
         
    }
}
