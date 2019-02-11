using CreditCardCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardCalculator.BLL
{
    public class CreditCalculator
    {
        public static double CalculateInterestPerPerson(Person person)
        {
            double amtInterest = 0.0;
            foreach(Wallet wallet in person.Wallets)
            {
                amtInterest += CalculateInterestPerWallet(wallet);
            }
            return amtInterest;
        }


        public static double CalculateInterestPerWallet(Wallet wallet)
        {
            double amtInterest = 0.0;
            foreach(CreditCard card in wallet.CreditCards)
            {
                amtInterest += CalculateInterestPerCard(card);
            }
            return amtInterest;
        }

        public static double CalculateInterestPerCard(CreditCard card)
        {
            double amtInterest = 0.0;
            double interestPercent = (double)card.CCType / 100;

            amtInterest = interestPercent * card.CardBalance;

            return amtInterest;
        }
    }
}
