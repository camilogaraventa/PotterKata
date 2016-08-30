using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.HarryPotter
{
    public static class BookPriceCalculator
    {
        #region Methods

        public static Decimal Calculate(List<Int32> books)
        {
            if (books.Distinct().Count() == 2)
            {
                return books.Count * 8 * 0.95m;
            }
            else if(books.Distinct().Count() == 3)
            {
                return books.Count * 8 * 0.9m;
            }
            else if (books.Distinct().Count() == 4)
            {
                return books.Count * 8 * 0.8m;
            }
            else
            {
                return books.Count * 8;
            }
        }
        
        #endregion
    }
}
