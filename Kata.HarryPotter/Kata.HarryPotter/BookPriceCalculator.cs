using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.HarryPotter
{
    public class BookPriceCalculator
    {
        #region Members

        private const Decimal singlePrice = 8;
        private const Decimal twoBooksDiscountFactor = 0.95m;
        private const Decimal threeBooksDiscountFactor = 0.9m;
        private const Decimal fourBooksDiscountFactor = 0.8m;
        private const Decimal fiveBooksDiscountFactor = 0.75m;
        private List<BooksCombo> _combos;

        #endregion

        public BookPriceCalculator()
        {
            this._combos = new List<BooksCombo>();
        }

        #region Methods

        public Decimal Calculate(List<Int32> books)
        {
            if (!books.Any())
                return 0;

            this.CalculateCombos(books);

            Decimal minPrice = Decimal.MaxValue;

            foreach (BooksCombo combo in this._combos)
            {
                Decimal comboPrice = CalculateComboPrice(combo);

                if (comboPrice < minPrice)
                {
                    minPrice = comboPrice;
                }
            }

            return minPrice;
        }

        private Decimal CalculateComboPrice(BooksCombo combo)
        {
            Decimal comboPrice = 0;

            foreach (List<Int32> books in combo.Groups)
            {
                Decimal discountFactor = CalculateDiscountFactor(books);
                comboPrice += books.Count * singlePrice * discountFactor;
            }

            return comboPrice;
        }

        private void CalculateCombos(List<Int32> books)
        {
            this._combos = new List<BooksCombo>();

            List<Tuple<Int32, Int32>> booksAmmount = books.Distinct().Select(b => new Tuple<Int32, Int32>(b, books.Count(bk => bk == b))).ToList();

            Int32 max = booksAmmount.Max(ba => ba.Item2);

            BooksCombo combo = new BooksCombo();

            for (Int32 i = 0; i < max; i++)
            {
                List<Int32> booksGroup = new List<Int32>();
                foreach (Tuple<Int32, Int32> bookAmmount in booksAmmount)
                {
                    if (bookAmmount.Item2 > i)
                    {
                        booksGroup.Add(bookAmmount.Item1);
                    }
                }
                combo.AddBooks(booksGroup.ToArray());
            }

            this._combos.Add(combo);

        }

        private Decimal CalculateDiscountFactor(List<Int32> books)
        {
            if (books.Distinct().Count() == 2)
            {
                return twoBooksDiscountFactor;
            }
            else if (books.Distinct().Count() == 3)
            {
                return threeBooksDiscountFactor;
            }
            else if (books.Distinct().Count() == 4)
            {
                return fourBooksDiscountFactor;
            }
            else if (books.Distinct().Count() == 5)
            {
                return fiveBooksDiscountFactor;
            }
            else
            {
                return 1;
            }
        }

        #endregion

    }
}
