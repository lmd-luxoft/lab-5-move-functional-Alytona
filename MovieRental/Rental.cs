// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Text;

namespace MovieRental
{
    internal class Rental
    {
        public readonly Movie Movie;
        public readonly int DaysRented;

        public readonly double Amount;
        public readonly int BonusPoints;

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;

            Amount = Movie.PriceStrategy.computePrice( DaysRented );

            //добавить очки для активного арендатора
            BonusPoints = Movie.PriceStrategy.getBonusPoints( DaysRented ) + 1;
        }

        public void addToReport (StringBuilder report)
        {
            report.AppendLine( $"\t{Movie}\t{Amount}" );
        }
    }
}