using System.Globalization;

namespace PicnicDemo
{
    public class Register
    {
        // properties
        public static decimal GrandTotal {  get; private set; }
        public decimal Total { get; private set; }

        // constructor
        public static void ResetGrandTotal()
        {
            GrandTotal = 0.00M;
        }

        // methods
        // increments totals, confirms inventory was sold
        public bool Sale(decimal amount)
        {
            if (amount > 0.00M)
            {
                Total += amount;
                GrandTotal += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        // overrides
        public override string ToString()
        {
            return Total.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
