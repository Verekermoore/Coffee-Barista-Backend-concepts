using System;
using System.Collections.Generic;
using System.Text;

namespace everyThingILearndSoFar
{
    // this class is created to store the information from the order like recpeit but neeeded in order to store multi orders
    /* 
     * this will store the coffee name the price the amount then in the receipt we creeate a list that will caputurre the data stored in the 
        order class.
     * in the receipt class it will display the name of the customer the total price and takes information formt he order class
    */
    internal class Order
    {
        public string Orders;
        public double amount;
        public double price;
    }
}
