// all notes are on one drive personal
using System;
using Newtonsoft.Json;
using everyThingILearndSoFar;

namespace everyThingILearndSoFar
{
    internal class Program
    {
        static void Main(string[] args)
        {

            coffeeOrder Customer = new coffeeOrder();

            // This list stores every customer's completed receipt.
            // It is created outside the customer loop so it is not reset each time a new customer is served.
            // If this list was inside the loop, all previous customers would be lost because a new empty list
            // would be created for every customer.
            List<Receipt> receipts = new List<Receipt>();



            //each coffee order amount  variables to store the cost of each coffee
            double subTotal1 = 0;
            double subTotal2 = 0;
            double subTotal3 = 0;
            double subTotal4 = 0;

            //loop over the whole program ensuing it continues for each customer
            bool a = true;
            while (a) 
            {

                // Create a new Receipt object for each new customer.
                // This must be inside the customer loop so every customer gets their own separate receipt.
                // If this was outside the loop, every customer would share the same Receipt object,
                // causing the previous customer's information to be overwritten.
                Receipt receipt = new Receipt();


                // greetings to the customer
                Console.WriteLine("Welcome to the Coffee Shop!");
            // looping over customer choice to ensue they pick an item 
            bool b = true;
                while (b)
                {
                    //put the customer order into a class to store the information for the receipt and to be ablke to store teh muitiple orders the customer might want to make. which requiers this in the smae loop to ensure it does not get over ridden.
                    Order order = new Order();

                    //displaying to customer coffee selection and how to chooce form the selection 
                    Console.WriteLine("What would you like to order, please enter the number that corresponds to your choice?");
                    Console.WriteLine("This is our menu: \n1. Espresso \n2. Latte \n3. Cappuccino \n4. Americano");
                    string choice = Console.ReadLine();
                    // based on what the customer slects if and else ifs to add more depth to the customer choice getting the amount of the porduct they want  
                    if (choice == "1")
                    {
                        Console.WriteLine("How many Espresso's would you like to order?");
                        int numberOfEspresso = Convert.ToInt32(Console.ReadLine());
                        order.Orders = Customer.choice1;
                        order.amount = numberOfEspresso;
                        subTotal1 = order.amount * Customer.price1;
                        order.price = subTotal1;



                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("How many Latte's would you like to order?");
                        int numberOfLatte = Convert.ToInt32(Console.ReadLine());
                        order.Orders = Customer.choice2;
                        order.amount = numberOfLatte;
                        subTotal2 = order.amount * Customer.price2;
                        order.price = subTotal2;




                    }
                    else if (choice == "3")
                    {
                        Console.WriteLine("How many Cappuccino's would you like to order");
                        int numberOfCappuccino = Convert.ToInt32(Console.ReadLine());
                        order.Orders = Customer.choice3;
                        order.amount = numberOfCappuccino;
                        subTotal3 = order.amount * Customer.price3;
                        order.price = subTotal3;



                    }
                    else if (choice == "4")
                    {
                        Console.WriteLine("How many Americano's would you like to order?");
                        int numberOfAmericano = Convert.ToInt32(Console.ReadLine());
                        order.Orders = Customer.choice4;
                        order.amount = numberOfAmericano;
                        subTotal4  = order.amount * Customer.price4;
                        order.price = subTotal4;

                    }
                    // else used to catch items that do not fall into the choices above as well as cathcing accdentel Enter pressing.
                    else
                    {
                        Console.WriteLine("Invalid choice, please try again. Your awnser should be a number between 1 and 4 that corasponds  with the menu item.");
                        Console.WriteLine("\nPlease press enter to try again.");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    Console.WriteLine("Anything else?" + "\nPlease enter yes or no to continue  choosing");
                    string More = Console.ReadLine();
                    More =More.ToLower();
                    if (More == "yes")
                    {
                        b = true;
                    }
                    else if (More == "no")
                    {
                        b = false;

                    }
                    else
                    {
                        Console.WriteLine("Please enter yes or no");
                    }

                    receipt.totalPrice =  subTotal1 + subTotal2 + subTotal3 + subTotal4;
                    receipt.eachOrder.Add(order);

                }

                // to ger the customers name so when we create a receipt or when they want a receipt then we search there info based on name.
                // migth add last name to and an id for people who might have same names.
                Console.WriteLine("What is your name?");
                receipt.Name = Console.ReadLine();
                receipts.Add(receipt);

                // this wont be used as does nto make sense to the structure of the code was gonna yse this to then create the
                // ability for the user to say what their order is so you can hypathetacly give them the order however it terms of
                // logical code why would you ask the user to tell you what they just ordered.

                /*
                // Loop through every receipt stored in the receipts list.
                // 'k' represents the current customer's receipt.
                // Always use 'k' inside this loop (k.Name, k.eachOrder, k.totalPrice)
                // because 'receipt' refers to the most recently created Receipt object,
                // while 'k' changes to each receipt as the loop runs.
                foreach (Receipt k in receipts)
                {
                    Console.WriteLine("Name: " + k.Name);

                    // Loop through every coffee order that belongs to the current customer.
                    // 'j' represents one Order object from the current receipt.
                    // Use 'j' to access the coffee name, quantity and price.
                    foreach (Order j in k.eachOrder)
                    {
                        Console.WriteLine("Coffee: " + j.Orders);
                        Console.WriteLine("Quantity: " + j.amount);
                        Console.WriteLine("Price: " + j.price);
                    }
                    Console.WriteLine("Total Price: " + k.totalPrice);

                }*/


                Console.WriteLine("Would you like a receipt? Please enter yes or no");
                string receiptChoice = Console.ReadLine();
                receiptChoice = receiptChoice.ToLower();
                if (receiptChoice == "yes")
                {
                    // convert to json which is used for frontend to send and recive information form the front end
                    string json = JsonConvert.SerializeObject(receipt);
                    File.WriteAllText("json.txt", json);
                    string jsonText = File.ReadAllText("json.txt");
                    // convert back to c#
                    Receipt deseralizaton = JsonConvert.DeserializeObject<Receipt>(jsonText);
                    // out put information to console in the receipt formate.
                    Console.WriteLine("Name: " + deseralizaton.Name);
                    foreach (Order i in deseralizaton.eachOrder)
                    {
                        Console.WriteLine("Coffee: " + i.Orders);
                        Console.WriteLine("Quantity: " + i.amount);
                        Console.WriteLine("Price: " + i.price);
                    }
                    Console.WriteLine("Total Price: " + deseralizaton.totalPrice);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (receiptChoice == "no")
                {
                    Console.WriteLine("Thank you for your order!");
                }
                else
                {
                    Console.WriteLine("Please enter yes or no");
                }


            }

        }
    }
}
