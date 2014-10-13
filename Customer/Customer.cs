using System;
using System.Collections.Generic;

namespace Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private int iD;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private IList<Payment> payments;
        private EnumCustomerType typeOfCustomer;

        public Customer (string firstName, string middleName, string lastName, int iD,
                            string permanentAddress, string mobilePhone, string email, 
                                IList<Payment> payments, EnumCustomerType typeOfCustomer)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = iD;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.TypeOfCustomer = typeOfCustomer;
        }

        public string FirstName 
        { 
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The first name cannot be empty.");
                }
                this.firstName = value;
            }
        }

        public string MiddleName 
        { 
            get
            {
                return this.middleName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The middle name cannot be empty.");
                }
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The last name cannot be empty.");
                }
                this.lastName = value;
            }
        }

        public int ID
        { 
            get
            {
                return this.iD;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The ID cannot be negative.");
                }
                this.iD = value;
            }
        }

        public string PermanentAddress 
        {
            get
            {
                return this.permanentAddress;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The permanent address cannot be empty.");
                }
                this.permanentAddress = value;
            }
        }

        public string MobilePhone 
        {
            get
            {
                return this.mobilePhone;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The mobile phone cannot be empty.");
                }
                this.mobilePhone = value;
            }
        }

        public string Email 
        {
            get
            {
                return this.email;
            }
            set
            {
                if (!value.Contains("@"))
                {
                    throw new ArgumentException("Invalid email.");
                }
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The email cannot be empty.");
                }
                this.email = value;
            }
        }

        public IList<Payment> Payments 
        {
            get
            {
                return this.payments;
            }
            set
            {
                this.payments = value;
            }
        }

        public EnumCustomerType TypeOfCustomer
        {
            get
            {
                return this.typeOfCustomer;
            }
            set
            {
                this.typeOfCustomer = value;
            }
        }

        public void AddPayment(Payment payment)
        {
            this.payments.Add(payment);
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;

            if (customer == null)
            {
                return false;
            }
            if (!Object.Equals(this.FirstName, customer.FirstName))
            {
                return false;
            }
            if (!Object.Equals(this.MiddleName, customer.MiddleName))
            {
                return false;
            }
            if (!Object.Equals(this.LastName, customer.LastName))
            {
                return false;
            }
            if (this.ID != customer.ID)
            {
                return false;
            }
            if (!Object.Equals(this.PermanentAddress, customer.PermanentAddress))
            {
                return false;
            }
            if (!Object.Equals(this.MobilePhone, customer.MobilePhone))
            {
                return false;
            }
            if (!Object.Equals(this.Email, customer.Email))
            {
                return false;
            }
            if (!Object.Equals(this.Payments.Count, customer.Payments.Count))
            {
                return false;
            }
            for (int i = 0; i < Payments.Count; i++)
            {
                if (!Object.Equals(this.Payments[i], customer.Payments[i]))
            {
                return false;
            }
            }
            if (!Object.Equals(this.TypeOfCustomer, customer.TypeOfCustomer))
            {
                return false;
            }
            return true;
        }

        public static bool operator == (Customer firstCustomer, Customer secondCustomer)
        {
            return Customer.Equals(firstCustomer, secondCustomer);
        }

        public static bool operator != (Customer firstCustomer, Customer secondCustomer)
        {
            return !(Customer.Equals(firstCustomer, secondCustomer));
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode()^
                   this.MiddleName.GetHashCode()^
                   this.LastName.GetHashCode()^
                   this.ID.GetHashCode()^
                   this.PermanentAddress.GetHashCode()^
                   this.MobilePhone.GetHashCode()^
                   this.Email.GetHashCode()^
                   this.Payments.GetHashCode()^
                   this.TypeOfCustomer.GetHashCode();
        }

        public override string ToString()
        {
            string paymentsAsString = "";
            foreach (var payment in payments)
            {
                paymentsAsString += payment + "\n";
            }
            return string.Format("Customer: {0} {1} {2}\nID: {3}\nType: {4}\nPermanent address: {5}\nMobile phone: {6}\nEmail: {7}\nPayments:\n{8}",
                                    this.FirstName,
                                    this.MiddleName,
                                    this.LastName,
                                    this.ID,
                                    this.TypeOfCustomer,
                                    this.PermanentAddress,
                                    this.MobilePhone,
                                    this.Email,
                                    paymentsAsString);
        }



        public object Clone()
        {
            Payment[] clonePayments = new Payment[this.Payments.Count];

            for (int i = 0; i < this.Payments.Count; i++)
            {
                clonePayments[i] = this.Payments[i];
            }

            return new Customer(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.ID,
                this.PermanentAddress,
                this.MobilePhone,
                this.Email,
                clonePayments,
                this.TypeOfCustomer
                );
        }

        public int CompareTo(Customer other)
        {
            string fullNameOfThisCustomer = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            string fullNameOfOtherCustomer = other.FirstName + " " + other.MiddleName + " " + other.LastName;

            if (fullNameOfThisCustomer.CompareTo(fullNameOfOtherCustomer) == 0)
            {
                return this.ID.CompareTo(other.ID);
            }

            return fullNameOfThisCustomer.CompareTo(fullNameOfOtherCustomer);
        }
    }
}
