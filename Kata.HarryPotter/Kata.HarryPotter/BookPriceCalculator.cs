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
            Decimal discountFactor = CalculateDiscountFactor(books);

            return books.Count * 8 * discountFactor;
        }

        private static Decimal CalculateDiscountFactor(List<Int32> books)
        {
            if(books.Distinct().Count() == 2)
            {
                return 0.95m;
            }
            else if (books.Distinct().Count() == 3)
            {
                return 0.9m;
            }
            else if (books.Distinct().Count() == 4)
            {
                return 0.8m;
            }
            else if (books.Distinct().Count() == 5)
            {
                return 0.75m;
            }
            else
            {
                return 1;
            }
        }

        #endregion
    }
}
