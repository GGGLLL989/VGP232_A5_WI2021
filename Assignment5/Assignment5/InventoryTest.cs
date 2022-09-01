using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    class InventoryTest
    {
        
        private Inventory inventory;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory(2);
            inventory.AddItem(new Item("A", 1, ItemGroup.Consumable));
        }

        

        [Test]
        public void Inventory_RemoveItem_AddItem_Reset()
        {
            // RemoveItem
            Item found;
            int slots = inventory.AvailableSlots;
            Assert.IsTrue(inventory.TakeItem("A", out found));
            Assert.NotNull(found);
            Assert.AreEqual(slots + 1, inventory.AvailableSlots);

            slots = inventory.AvailableSlots;
            Assert.IsFalse(inventory.TakeItem("A", out found));
            Assert.IsNull(found);
            Assert.AreEqual(slots, inventory.AvailableSlots);


            // AddItem
            Item item1 = new Item("B", 1, ItemGroup.Key);
            Item item2 = new Item("C", 1, ItemGroup.Equipment);
            Assert.IsTrue(inventory.AddItem(item1));
            Assert.IsTrue(inventory.AddItem(item2));
            Assert.IsFalse(inventory.AddItem(new Item("D", 1, ItemGroup.Equipment)));
            Assert.AreEqual(0, inventory.AvailableSlots);

            List<Item> items = inventory.ListAllItems();
            Assert.AreEqual(item1, items[0]);
            Assert.AreEqual(item2, items[1]);

            // Reset
            inventory.Reset();
            Assert.AreEqual(inventory.AvailableSlots, inventory.MaxSlots);
        }

    }
}
