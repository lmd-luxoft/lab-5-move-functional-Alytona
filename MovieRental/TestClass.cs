// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace MovieRental
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void NameFilmShouldBeCorrect()
        {
	        Movie movie = new Movie( "Rio2", Movie.NewReleasePriceStrategy );
            Assert.AreEqual("Rio2", movie.Title);
        }
        [Test]
        public void TypeFilmShouldBeCorrect ()
        {
            Movie movie = new Movie( "Rio2", Movie.NewReleasePriceStrategy );
            Assert.AreEqual( Movie.NewReleasePriceStrategy, movie.PriceStrategy );
        }
        [Test]
        public void RentalShouldBeCorrectMovie()
        {
            Movie movie = new Movie("Angry Birds", Movie.RegularPriceStrategy);
            Rental rental = new Rental(movie, 20);
            Assert.AreEqual(movie, rental.Movie);
        }
        [Test]
        public void RentalShouldBeCorrectDayRented()
        {
            Movie movie = new Movie("Angry Birds", Movie.RegularPriceStrategy);
            Rental rental = new Rental(movie, 20);
            Assert.AreEqual(20, rental.DaysRented);
        }
        [Test]
        public void CustomerShouldBeCorrectName()
        {
            Customer customer = new Customer("Bug");
            Assert.AreEqual( "Bug", customer.Name );
        }
        [Test]
        public void CustomerCreateCorrectStatement()
        {
            Customer customer = new Customer("Bug");

            Movie movie1 = new Movie("Angry Birds", Movie.ChildrenPriceStrategy);
            Rental rental1 = new Rental(movie1, 2);
            customer.addRental(rental1);

	        Movie movie2 = new Movie("StarWar", Movie.NewReleasePriceStrategy);
            Rental rental2 = new Rental(movie2, 10);
            customer.addRental(rental2);

	        Movie movie3 = new Movie("Hatico", Movie.RegularPriceStrategy);
            Rental rental3 = new Rental(movie3, 4);
            customer.addRental(rental3);

            string actual = customer.statement();
            Assert.AreEqual("учет аренды для Bug\r\n\tAngry Birds\t15\r\n\tStarWar\t30\r\n\tHatico\t32\r\nСумма задолженности составляет 77\r\nВы заработали 4 очков за активность", actual);
        }
        [Test]
        public void CustomerCreateCorrectStatementWithoutNewReleaseBonuses ()
        {
            Customer customer = new Customer( "Bug" );

            Movie movie2 = new Movie( "StarWar", Movie.NewReleasePriceStrategy );
            Rental rental2 = new Rental( movie2, 1 );
            customer.addRental( rental2 );

            Movie movie3 = new Movie( "Hatico", Movie.RegularPriceStrategy );
            Rental rental3 = new Rental( movie3, 4 );
            customer.addRental( rental3 );

            string actual = customer.statement();
            Assert.AreEqual( "учет аренды для Bug\r\n\tStarWar\t3\r\n\tHatico\t32\r\nСумма задолженности составляет 35\r\nВы заработали 2 очков за активность", actual );
        }
        [Test]
        public void BonusPriceStrategyCorrectPrice ()
        {
            IPriceStrategy bonusPriceStrategy = new BonusPriceStrategy( multiplicator: 3, daysForActivityBonus: 1 );
            Assert.AreEqual( 30, bonusPriceStrategy.computePrice( 10 ) );
        }
        [Test]
        public void BonusPriceStrategyCorrectBonuses ()
        {
            IPriceStrategy bonusPriceStrategy = new BonusPriceStrategy( multiplicator: 3, daysForActivityBonus: 1 );
            Assert.AreEqual( 0, bonusPriceStrategy.getBonusPoints( 1 ) );
        }
        [Test]
        public void BonusPriceStrategyCorrectBonusesForMoreThanOneDays ()
        {
            IPriceStrategy bonusPriceStrategy = new BonusPriceStrategy( multiplicator: 3, daysForActivityBonus: 1 );
            Assert.AreEqual( 1, bonusPriceStrategy.getBonusPoints( 2 ) );
        }
        [Test]
        public void RegularPriceStrategyCorrectPriceOneDay ()
        {
            IPriceStrategy bonusPriceStrategy = new RegularPriceStrategy( multiplicator: 15, basePrice: 10, basePriceDays: 2 );
            Assert.AreEqual( 10, bonusPriceStrategy.computePrice( 1 ) );
        }
        [Test]
        public void RegularPriceStrategyCorrectPriceTwoDays ()
        {
            IPriceStrategy bonusPriceStrategy = new RegularPriceStrategy( multiplicator: 15, basePrice: 10, basePriceDays: 2 );
            Assert.AreEqual( 10, bonusPriceStrategy.computePrice( 2 ) );
        }
        [Test]
        public void RegularPriceStrategyCorrectPriceThreeDays ()
        {
            IPriceStrategy bonusPriceStrategy = new RegularPriceStrategy( multiplicator: 15, basePrice: 10, basePriceDays: 2 );
            Assert.AreEqual( 25, bonusPriceStrategy.computePrice( 3 ) );
        }
    }
}
