// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace MovieRental
{
    public class Movie
    {
        internal static IPriceStrategy RegularPriceStrategy = new RegularPriceStrategy( multiplicator: 15, basePrice: 2, basePriceDays: 2 );
        internal static IPriceStrategy ChildrenPriceStrategy = new RegularPriceStrategy( multiplicator: 15, basePrice: 15, basePriceDays: 3 );

        ////бонус за аренду новинки на два дня
        internal static IPriceStrategy NewReleasePriceStrategy = new BonusPriceStrategy( multiplicator: 3, daysForActivityBonus: 1 );

        public readonly string Title;

        internal readonly IPriceStrategy PriceStrategy;

        public Movie(string title, IPriceStrategy priceStrategy)
        {
            Title = title;
            PriceStrategy = priceStrategy;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}