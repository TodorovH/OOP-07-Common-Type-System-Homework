using System;
using System.Collections.Generic;

namespace Customer
{
    class CustomerTest
    {
        static void Main(string[] args)
        {
            Payment paymentForSamsung = new Payment("Sumsung", 1200m);
            Payment paymentForCar = new Payment("SomeCar", 10000m);
            Payment paymentForMobilePhone = new Payment("Galaxy", 900m);

            Customer pesho = new Customer(
                "Pesho",
                "Peshev",
                "Peshov",
                621212337,
                "SomeAddress",
                "SomeMobilePhone",
                "Some@email",
                new List<Payment>() { paymentForSamsung, paymentForMobilePhone, paymentForCar },
                EnumCustomerType.Diamond);

            Customer gosho = new Customer(
                "Gosho", 
                "Goshev", 
                "Goshev",
                621212334, 
                "OtherAddress",
                "OtherPhone", 
                "gosho@abv.bg",
                new List<Payment>() { paymentForSamsung, paymentForMobilePhone },
                EnumCustomerType.Golden);

            Customer peshoPeshev = new Customer(
                "Pesho", 
                "Peshev", 
                "Peshev", 
                311214244, 
                "SomeOtherAddress",
                "SomeOtherMobilePhone",
                "pesho@abv.bg",
                new List<Payment>() { paymentForSamsung, paymentForCar },
                EnumCustomerType.OneTime);

            Console.WriteLine("Are gosho and pesho equal: {0}", Equals(gosho, pesho));
            Console.WriteLine("Are pesho and pesho peshev equal: {0}", Equals(pesho, peshoPeshev));
            Console.WriteLine("Are gosho and pesho equal using '==': {0}", (gosho == pesho));
            Console.WriteLine(gosho);
            Console.WriteLine("Pesho Peshev HashCode is: {0}", peshoPeshev.GetHashCode());

            var nasko = (Customer)peshoPeshev.Clone();
            nasko.FirstName = "Nasko";
            nasko.MiddleName = "Atanasov";
            nasko.LastName = "Naskov";
            Console.WriteLine();
            Console.WriteLine("Original after cloning: {0}", peshoPeshev);
            Console.WriteLine();
            Console.WriteLine("Clone: {0}", nasko);

            var atanas = (Customer)nasko.Clone();
            atanas.ID = 411214244;
            Customer[] customers = { gosho, atanas, nasko, peshoPeshev };
            Array.Sort(customers);
            Console.WriteLine();
            Console.WriteLine("Sorted customers(Full Name, ID):");
            foreach (var customer in customers)
            {
                string fullNameOfTheCustomer = customer.FirstName + " " + customer.MiddleName + " " + customer.LastName;
                Console.WriteLine(fullNameOfTheCustomer + " " + customer.ID);
            }
        }
    }
}
