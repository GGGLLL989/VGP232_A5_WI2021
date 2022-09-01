using System;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            // TODO: Create an inventory
            // TODO: Add 2 items to the inventory
            // Verify the number of items in the inventory.
            Inventory inventory = new Inventory(5);
            inventory.AddItem(new Item("wood", 1, ItemGroup.Consumable));
            inventory.AddItem(new Item("stone", 1, ItemGroup.Consumable));
            Console.WriteLine("Two items has been added into the inventory.");
            if (inventory.MaxSlots - inventory.AvailableSlots == 2)
            {
                Console.WriteLine("The inventory has correct capacity.");
            }
            else
            {
                Console.WriteLine("The inventory has incorrect capacity.");
            }
        }
    }
}
