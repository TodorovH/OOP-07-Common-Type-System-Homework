using System;
using System.Collections;
using System.Collections.Generic;

namespace StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable
    {
        private string firstString;
        private string secondString;
        private string thirdString;
        private string forthString;
        private string fifthString;

        public string FirstString 
        { 
            get
            {
                return this.firstString;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("String cannot be empty.");
                }
                this.firstString = value;
            }
        }

        public string SecondString { get; set; }

        public string ThirdString { get; set; }

        public string ForthString { get; set; }

        public string FifthString { get; set; }

        public StringDisperser(string firstString, string secondString = null, string thirdString = null, string forthString = null, string fifthString = null)
        {
            this.FirstString = firstString;
            this.SecondString = secondString;
            this.ThirdString = thirdString;
            this.ForthString = forthString;
            this.FifthString = fifthString;
        }

        public override bool Equals(object obj)
        {
            StringDisperser stringDisperser = obj as StringDisperser;

            if (stringDisperser == null)
            {
                return false;
            }

            if (!Object.Equals(this.FirstString, stringDisperser.FirstString))
            {
                return false;
            }

            if ((this.SecondString != null) && (!Object.Equals(this.SecondString, stringDisperser.SecondString)))
            {
                return false;
            }

            if ((this.ThirdString != null) && (!Object.Equals(this.ThirdString, stringDisperser.ThirdString)))
            {
                return false;
            }

            if ((this.ForthString != null) && (!Object.Equals(this.ForthString, stringDisperser.ForthString)))
            {
                return false;
            }

            if ((this.FifthString != null) && (!Object.Equals(this.FifthString, stringDisperser.FifthString)))
            {
                return false;
            }

            return true;
        }

        public static bool operator == (StringDisperser firstStringDisperser, StringDisperser secondStringDisperser)
        {
            return StringDisperser.Equals(firstStringDisperser, secondStringDisperser);
        }

        public static bool operator !=(StringDisperser firstStringDisperser, StringDisperser secondStringDisperser)
        {
            return !(StringDisperser.Equals(firstStringDisperser, secondStringDisperser));
        }

        public override int GetHashCode()
        {
            return this.FirstString.GetHashCode()^
                   this.SecondString.GetHashCode()^
                   this.ThirdString.GetHashCode()^
                   this.ForthString.GetHashCode()^
                   this.FifthString.GetHashCode();
        }

        public override string ToString()
        {
            string result = "";
            result += this.FirstString;
            if (this.SecondString != null)
            {
                result += " " + this.SecondString;
            }
            if (this.ThirdString != null)
            {
                result += " " + this.ThirdString;
            }
            if (this.ForthString != null)
            {
                result += " " + this.ForthString;
            }
            if (this.FifthString != null)
            {
                result += " " + this.FifthString;
            }
            return result;
        }

        public object Clone()
        {
            return new StringDisperser(
                this.FirstString,
                this.SecondString,
                this.ThirdString,
                this.ForthString,
                this.FifthString
                );
        }



        public int CompareTo(StringDisperser other)
        {
            return this.ToString().CompareTo(other.ToString());
        }

        public IEnumerator GetEnumerator()
        {
            var result = this.FirstString + this.SecondString + this.ThirdString + this.ForthString + this.FifthString;

            for (int i = 0; i < result.Length; i++)
            {
                yield return result[i];
            }
        }
    }
}
