using System;

namespace Customer
{
    public class Payment
    {
        private string productName;
        private decimal price;

        public string ProductName
        { 
            get
            {
                return this.productName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The product name cannot be empty.");
                }
                this.productName = value;
            }
        }

        public decimal Price
        { 
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price cannot be negative.");
                }
                this.price = value;
            }
        }

        public Payment (string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.ProductName, this.Price);
        }
    }
}
