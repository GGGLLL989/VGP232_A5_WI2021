using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public enum ItemGroup { Consumable, Key, Equipment };
    public class Item
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public ItemGroup Group { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <param name="group"></param>
        public Item(string name, int amount, ItemGroup group)
        {
            Name = name;
            Amount = amount;
            Group = group;
        }

        public override string ToString()
        {
            // TODO: display the output like this Axe
            return string.Format("Name: {0}, Amount: {1}, Group: {2}",
                Name, Amount, Group);
        }
    }
}
