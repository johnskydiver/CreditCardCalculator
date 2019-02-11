using CreditCardCalculator.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class CreditCalculatorTests
    {
        [Test]
        public void CalcInterestForOnePersonWithThreeCardsForThisPersonAndPerCard()
        {
            //arrange
            var person = new Person() { Name = "John Smith", Wallets = new List<Wallet>() };
            person.Wallets.Add(new Wallet() { Name = "first wallet", CreditCards = new List<CreditCard>() });
            person.Wallets[0].CreditCards.Add(new CreditCard() { Name = "LoneStar Steakhouse", CardBalance = 100, CCType = CCType.Discover });
            person.Wallets[0].CreditCards.Add(new CreditCard() { Name = "Home Depot", CardBalance = 100, CCType = CCType.MasterCard });
            person.Wallets[0].CreditCards.Add(new CreditCard() { Name = "Best Buy", CardBalance = 100, CCType = CCType.Visa });

            //act
            var amtInterestForJohn = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerPerson(person);
            var amtInterestCard1 = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerCard(person.Wallets[0].CreditCards[0]);
            var amtInterestCard2 = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerCard(person.Wallets[0].CreditCards[1]);
            var amtInterestCard3 = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerCard(person.Wallets[0].CreditCards[2]);

            //assert
            Assert.That(amtInterestCard1, Is.EqualTo(1));
            Assert.That(amtInterestCard2, Is.EqualTo(5));
            Assert.That(amtInterestCard3, Is.EqualTo(10));
            Assert.That(amtInterestForJohn, Is.EqualTo(16));

        }

        [Test]
        public void CalcInterestForOnePersonWithTwoWallets()
        {
            //arrange
            var person = new Person() { Name = "John Smith", Wallets = new List<Wallet>() };
            person.Wallets.Add(new Wallet() { Name = "first wallet", CreditCards = new List<CreditCard>() });
            person.Wallets.Add(new Wallet() { Name = "second wallet", CreditCards = new List<CreditCard>() });
            person.Wallets[0].CreditCards.Add(new CreditCard() { Name = "LoneStar Steakhouse", CardBalance = 100, CCType = CCType.Discover });
            person.Wallets[0].CreditCards.Add(new CreditCard() { Name = "Home Depot", CardBalance = 100, CCType = CCType.Visa });
            person.Wallets[1].CreditCards.Add(new CreditCard() { Name = "Best Buy", CardBalance = 100, CCType = CCType.MasterCard });

            //act
            var amtInterestForJohn = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerPerson(person);
            var amtInterestWallet1 = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerWallet(person.Wallets[0]);
            var amtInterestWallet2 = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerWallet(person.Wallets[1]);

            //assert
            Assert.That(amtInterestWallet1, Is.EqualTo(11));
            Assert.That(amtInterestWallet2, Is.EqualTo(5));
            Assert.That(amtInterestForJohn, Is.EqualTo(16));
        }

        [Test]
        public void CalcInterestForTwoPeopleWithOneWalletAndTwoCardsEach()
        {
            //arrange
            var person1 = new Person() { Name = "John Smith", Wallets = new List<Wallet>() };
            person1.Wallets.Add(new Wallet() { Name = "first wallet", CreditCards = new List<CreditCard>() });
            person1.Wallets[0].CreditCards.Add(new CreditCard() { Name = "LoneStar Steakhouse", CardBalance = 100, CCType = CCType.MasterCard });
            person1.Wallets[0].CreditCards.Add(new CreditCard() { Name = "Home Depot", CardBalance = 100, CCType = CCType.Visa });

            var person2 = new Person() { Name = "Jason Jones", Wallets = new List<Wallet>() };
            person2.Wallets.Add(new Wallet() { Name = "first wallet", CreditCards = new List<CreditCard>() });
            person2.Wallets[0].CreditCards.Add(new CreditCard() { Name = "Best Buy", CardBalance = 100, CCType = CCType.MasterCard });
            person2.Wallets[0].CreditCards.Add(new CreditCard() { Name = "Local Diner", CardBalance = 100, CCType = CCType.Visa });

            //act
            var amtInterestForJohn = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerPerson(person1);
            var amtInterestJohnWallet1 = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerWallet(person1.Wallets[0]);

            var amtInterestForJason = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerPerson(person2);            
            var amtInterestJasonWallet1 = CreditCardCalculator.BLL.CreditCalculator.CalculateInterestPerWallet(person2.Wallets[0]);

            //assert
            Assert.That(amtInterestJohnWallet1, Is.EqualTo(15));
            Assert.That(amtInterestForJohn, Is.EqualTo(15));


            Assert.That(amtInterestJasonWallet1, Is.EqualTo(15));
            Assert.That(amtInterestForJason, Is.EqualTo(15));
        }
        
    }
}
