using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardCalculator.Data
{
    public class CreditCard
    {
        public string Name { get; set; }

        public CCType CCType { get; set; }

        public double CardBalance { get; set; }
    }

    public enum CCType { Visa = 10, MasterCard = 5, Discover = 1}
}
