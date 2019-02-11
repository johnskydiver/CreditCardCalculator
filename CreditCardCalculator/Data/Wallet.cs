using System.Collections.Generic;

namespace CreditCardCalculator.Data
{
    public class Wallet
    {
        public string Name { get; set; }
        public List<CreditCard> CreditCards { get; set; }
    }
}
