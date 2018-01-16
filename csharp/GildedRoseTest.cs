using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private static readonly String SULFURAS_NAME = "Sulfuras, Hand of Ragnaros";
    private static readonly String BACKSTAGE_PASS_NAME = "Backstage passes to a TAFKAL80ETC concert";
    private static readonly String AGED_BRIE_NAME = "Aged Brie";

    [Test]
        public void should_decrease_Quality_by_one()
        {
            Item item = newItem("", 0, 1);
            updateItems(item);
            Assert.AreEqual(item.Quality, 0);
        }

        [Test]
        public void should_not_decrease_Quality_if_sulfuras()
        {
            Item item = newItem(SULFURAS_NAME, 0, 1);
            updateItems(item);
            Assert.AreEqual(item.Quality, 1);
        }

        [Test]
        public void should_not_decrease_Quality_if_already_zero()
        {
            Item item = newItem("", 0, 0);
            updateItems(item);
            Assert.AreEqual(item.Quality, 0);
        }

        [Test]
        public void should_increase_Quality_by_two_if_backstage_sellin_is_under_11()
        {
            Item item = newItem(BACKSTAGE_PASS_NAME, 10, 1);
            updateItems(item);
            Assert.AreEqual(item.Quality, 3);
        }

        [Test]
        public void should_not_increase_Quality_over_50_if_backstage_sellin_is_under_11()
        {
            Item item = newItem(BACKSTAGE_PASS_NAME, 10, 49);
            updateItems(item);
            Assert.AreEqual(item.Quality, 50);
        }

        [Test]
        public void should_increase_Quality_by_three_if_backstage_sellin_is_under_6()
        {
            Item item = newItem(BACKSTAGE_PASS_NAME, 5, 1);
            updateItems(item);
            Assert.AreEqual(item.Quality, 4);
        }

        [Test]
        public void should_not_increase_Quality_over_50_if_backstage_sellin_is_under_6()
        {
            Item item = newItem(BACKSTAGE_PASS_NAME, 5, 49);
            updateItems(item);
            Assert.AreEqual(item.Quality, 50);
        }

        [Test]
        public void should_increase_Quality_if_aged_brie()
        {
            Item item = newItem(AGED_BRIE_NAME, 1, 1);
            updateItems(item);
            Assert.AreEqual(item.Quality, 2);
        }

        [Test]
        public void should_not_increase_Quality_over_50_if_aged_brie()
        {
            Item item = newItem(AGED_BRIE_NAME, 1, 50);
            updateItems(item);
            Assert.AreEqual(item.Quality, 50);
        }

        [Test]
        public void should_decrease_sellin()
        {
            Item item = newItem("", 1, 0);
            updateItems(item);
            Assert.AreEqual(item.SellIn, 0);
        }

        [Test]
        public void should_not_decrease_sellin_if_sulfuras()
        {
            Item item = newItem(SULFURAS_NAME, 1, 0);
            updateItems(item);
            Assert.AreEqual(item.SellIn, 1);
        }

        [Test]
        public void should_decrease_Quality_by_two_if_sellin_negative()
        {
            Item item = newItem("", 0, 2);
            updateItems(item);
            Assert.AreEqual(item.Quality, 0);
        }

        [Test]
        public void should_decrease_Quality_under_zero_if_sellin_negative()
        {
            Item item = newItem("", 0, 1);
            updateItems(item);
            Assert.AreEqual(item.Quality, 0);
        }

        [Test]
        public void should_set_Quality_to_zero_if_backstage_sellin_is_negative()
        {
            Item item = newItem(BACKSTAGE_PASS_NAME, 0, 10);
            updateItems(item);
            Assert.AreEqual(item.Quality, 0);
        }

        [Test]
        public void should_increase_Quality_by_two_if_brie_sellin_is_negative()
        {
            Item item = newItem(AGED_BRIE_NAME, 0, 1);
            updateItems(item);
            Assert.AreEqual(item.Quality, 3);
        }

        [Test]
        public void should_not_increase_Quality_over_50_if_brie_sellin_is_negative()
        {
            Item item = newItem(AGED_BRIE_NAME, 0, 49);
            updateItems(item);
            Assert.AreEqual(item.Quality, 50);
        }

        private Item newItem(String name, int sellIn, int quality)
        {
            return new Item
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            };
        }

        private void updateItems(params Item[] items)
        {
            new GildedRose(items).UpdateQuality();
        }
    }
}
