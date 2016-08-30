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
            if(books.Any())
            {
                return 8;
            }
            return 0;
        }

        #endregion
    }
}
