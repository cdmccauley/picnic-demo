using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PicnicDemo
{
    public class Cashier
    {
        // properties
        private Inventory Store { get; set; }
        private Dictionary<string, Register> Registers { get; set; }

        // constructor
        public Cashier()
        {
            Store = new Inventory();
            Registers = new Dictionary<string, Register>();
            Registers.Add("ticket", new Register());
            Registers.Add("food", new Register());
        }

        // methods
        // get users category abbreviation
        private char GetCustomerCategory()
        {
            Console.Write($"What are you buying, {string.Join(" or ", Store.Categories)}?: ");
            return Console.ReadLine()[0];
        }

        // get users item abbreviation
        private char GetCustomerItem(string category)
        {
            Console.WriteLine($"{category} Choices\n{string.Join("\n", Store.Items[category])}");
            Console.Write($"Which {category} item do you want? ({string.Join(", ", Store.Items[category].Select(item => $"{item.Name[0]}"))}): ");
            return Console.ReadLine()[0];
        }

        // get users quantity
        private int GetSaleQuantity(Item item)
        {
            Console.Write("How many do you want?: ");
            int quantity = int.Parse(Console.ReadLine());
            if (item.Quantity >= quantity)
                return quantity;
            else
                return 0;
        }

        // get sale payment
        private decimal GetCustomerPayment(decimal price)
        {
            decimal payment = 0.00M;
            if (price > 0.00M)
            {
                Console.Write($"That costs {price.ToString("C", CultureInfo.CurrentCulture)}, how much are you paying?: $");
                payment = decimal.Parse(Console.ReadLine()) - price;
                if (payment < 0.00M)
                {
                    payment = 0.00M;
                    Console.WriteLine("No sale, you didn't pay enough");
                }
                else
                {
                    Console.WriteLine($"The change is {payment.ToString("C", CultureInfo.CurrentCulture)}");
                    payment = price;
                }
            }
            else
            {
                Console.WriteLine("Not enough inventory to sale that much.");
            }
            return payment;
        }

        // list and sell items until user is done
        public void SellItems()
        {
            do
            {
                try
                {
                    string category = ConvertCharToCategory(GetCustomerCategory());
                    string itemName = ConvertCharToName(GetCustomerItem(category));
                    Item item = Store.Items[category].Find(item => item.Name.Equals(itemName));
                    int quantity = GetSaleQuantity(item);
                    bool success = Registers[category].Sale(GetCustomerPayment(item.Price * quantity));
                    if (success)
                        item.Quantity -= quantity;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.Write("More purchases (y/n)? ");
                }
            } while (Console.ReadLine().ToLower()[0].Equals('y'));
        }

        // display register totals
        public void ReportEarnings()
        {
            Console.WriteLine("At the end of the picnic:");
            Console.WriteLine(string.Join("\n", Registers.Keys.Select(registerKey => $"{registerKey} Total Sales: {Registers[registerKey]}").ToList()));
            Console.WriteLine($"Grand Total: {Register.GrandTotal.ToString("C", CultureInfo.CurrentCulture)}");
        }

        // lookup category based on first letter
        public string ConvertCharToCategory(char category)
        {
            // this only works because each category in this assignment has a unique first letter
            return Store.Items.Keys.Where(key => key[0] == category).First();
        }

        // lookup item based on first letter
        public string ConvertCharToName(char first)
        {
            // this only works because each item in this assignment has a unique first letter
            var item = Store.Items.Values.Aggregate(new List<Item>(), (x, y) => x.Concat(y).ToList()).Find(item => item.Name[0].Equals(first));
            if (item != null)
                return item.Name;
            else
                throw new Exception("Unable to find item using that character, try again");
        }
    }
}
