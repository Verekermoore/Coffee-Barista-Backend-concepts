using System;
using System.Collections.Generic;
using System.Text;

namespace everyThingILearndSoFar
{
    class Receipt
    {
        // store user name 
        public string Name;
        // this is used to diplay the list of itmes the user orders 
        public List<Order> eachOrder = new List<Order>();


        //this will be where the receipt displays the final total.
        public double totalPrice;

         
    }
}
