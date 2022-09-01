using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class Inventory
    {
        // The dictionary items consist of the item and the quantity
        private Dictionary<Item, int> items;

        public int AvailableSlots
        {
            get
            {
                return availableSlots;
            }
        }

        public int MaxSlots
        {
            get
            {
                return maxSlots;
            }
        }


        // The available slots to add item, once it's 0, you cannot add any more items.
        private int availableSlots;

        // The max available slots which is set only in the constructor.
        private int maxSlots;
        public Inventory(int slots)
        {
            maxSlots = slots;
            availableSlots = maxSlots;
            items = new Dictionary<Item, int>();
        }

        /// <summary>
        /// Removes all the items, and restore the original number of slots.
        /// </summary>
        public void Reset()
        {
            items.Clear();
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes the item from the items dictionary if the count is 1 otherwise decrease the quantity.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <param name="found">The item if found</param>
        /// <returns>True if you find the item, and false if it does not exist.</returns>
        public bool TakeItem(string name, out Item found)
        {
            // First find the item
            found = null;
            foreach (var pair in items)
            {
                if (pair.Key.Name == name)
                {
                    found = pair.Key;
                    break;
                }
            }
            if (found == null)
            {
                return false;
            }
            // Take this item
            items[found] -= 1;
            if (items[found] <= 0)
            {
                // Remove the item if its quantity is zero
                items.Remove(found);
            }
            availableSlots++;
            return true;
        }

        /// <summary>
        /// Checks if there is space for a unique item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddItem(Item item)
        {
            // Add it in the items dictionary and increment it the number if it already exist
            // Reduce the slot once it's been added.
            // returns false if the inventory is full
            if (availableSlots <= 0)
            {
                return false;
            }
            if (items.ContainsKey(item))
            {
                // Increase the quantity of the item
                items[item] += 1;
            }
            else
            {
                // Add a new item
                items.Add(item, 1);
            }
            availableSlots--;
            return true;
        }

        /// <summary>
        /// Iterates through the dictionary and create a list of all the items.
        /// </summary>
        /// <returns></returns>
        public List<Item> ListAllItems()
        {
            // use a foreach loop to iterate through the key value pairs and duplicate the item base on the quantity.
            List<Item> mItems = new List<Item>();
            foreach (KeyValuePair<Item, int> pair in items)
            {
                mItems.Add(pair.Key);
            }
            return mItems;
        }
    }
}
