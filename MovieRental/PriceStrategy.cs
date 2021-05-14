using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental
{
    public interface IPriceStrategy
    {
        double computePrice (int daysRented);
        int getBonusPoints (int daysRented);
    }

    internal class BonusPriceStrategy : IPriceStrategy
    {
        private readonly double _multiplicator;
        private readonly int _daysForActivityBonus;

        public BonusPriceStrategy (double multiplicator, int daysForActivityBonus = 1)
        {
            _multiplicator = multiplicator;
            _daysForActivityBonus = daysForActivityBonus;
        }
        public double computePrice (int daysRented)
        {
            return daysRented * _multiplicator;
        }
        public int getBonusPoints (int daysRented)
        {
            return daysRented > _daysForActivityBonus ? 1 : 0;
        }
    }
    internal class RegularPriceStrategy : IPriceStrategy
    {
        private readonly double _basePrice;
        private readonly double _multiplicator;
        private readonly int _basePriceDays;

        public RegularPriceStrategy (double multiplicator, double basePrice = 2, int basePriceDays = 2)
        {
            _multiplicator = multiplicator;
            _basePrice = basePrice;
            _basePriceDays = basePriceDays;
        }
        public double computePrice (int daysRented)
        {
            double price = _basePrice;
            if (daysRented > _basePriceDays)
                price += (daysRented - _basePriceDays) * _multiplicator;
            return price;
        }
        public int getBonusPoints (int daysRented)
        {
            return 0;
        }
    }
}
