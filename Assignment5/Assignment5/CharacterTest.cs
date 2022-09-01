using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    class CharacterTest
    {
        private Character character;

        [SetUp]
        public void SetUp()
        {
            character = new Character("Enemy", RaceCategory.Elf, 100);
        }

        [Test]
        public void Character_TakeDamage_RestoreHealth()
        {
            // TakeDamage
            character.TakeDamage(10);
            Assert.AreEqual(90, character.Health);
            Assert.IsTrue(character.IsAlive);
            character.TakeDamage(95);
            Assert.AreEqual(0, character.Health);
            Assert.IsFalse(character.IsAlive);

            // RestoreHealth
            character.RestoreHealth(20);
            Assert.AreEqual(20, character.Health);
            Assert.IsTrue(character.IsAlive);
        }
    }
}
