using System.Globalization;

namespace PicnicDemo
{
    public class Item
    {
        // properties
        public string Name { get; set; }
        public decimal Price {  get; set; }
        public int Quantity {  get; set; }

        // constructor
        public Item(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        // overrides
        public override string ToString()
        {
            return $"{Name}, {Price.ToString("C", CultureInfo.CurrentCulture)}";
        }
    }
}
