using System.Collections.Generic;
using System.Linq;

namespace PicnicDemo
{
    public class Inventory
    {
        // properties
        public IEnumerable<string> Categories 
        { 
            get { return Items.Keys.Select(category => $"{category} ({category[0]})"); }
            private set { }
        }
        public Dictionary<string, List<Item>> Items { get; set; }
        
        // constructor
        public Inventory()
        {
            Items = new Dictionary<string, List<Item>>();
            Items.Add("ticket", new List<Item>()
            { 
                new Item("raffle ticket", 5.00M, int.MaxValue),
            });
            Items.Add("food", new List<Item>()
            {
                new Item("hot dog", 1.50M, 5),
                new Item("soda", 2.00M, 5),
                new Item("cotton candy", 4.50M, 3)
            });
        }
    }
}
