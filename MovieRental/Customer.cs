// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public readonly string Name;

        public Customer(string name)
        {
            this.Name = name;
        }

        internal void addRental(Rental rental)
        {
           _rentals.Add(rental);
        }

        internal string statement()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine( $"учет аренды для {Name}" );
            double totalAmount = 0;
            
            int frequentRenterPoints = 0;
            foreach (var item in _rentals)
            {
                double thisAmount = item.Movie.PriceStrategy.computePrice( item.DaysRented );

                //добавить очки для активного арендатора
                frequentRenterPoints++;
                frequentRenterPoints += item.Movie.PriceStrategy.getBonusPoints( item.DaysRented );

                report.AppendLine($"\t{item.Movie}\t{thisAmount}");
               
                totalAmount += thisAmount;
            }

            report.AppendLine( $"Сумма задолженности составляет {totalAmount}" );
            report.Append( $"Вы заработали {frequentRenterPoints} очков за активность" );
            return report.ToString();
        }
    }
}