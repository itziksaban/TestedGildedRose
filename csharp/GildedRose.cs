using System.Collections.Generic;
using System.Diagnostics;

namespace csharp
{
    public class GildedRose
    {
        public const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string Conjured = "Conjured";
        IList<Item> Items;


        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                IItemUpdater itemUpdater = GetUpdater(item);
                itemUpdater.Update(item);
            }
        }

        private IItemUpdater GetUpdater(Item item)
        {
            switch (item.Name)
            {
                case GildedRose.AgedBrie:
                    return new AgedBrieUpdater();
                case GildedRose.Backstage:
                    return new BackstageUpdater();
                case GildedRose.Sulfuras:
                    return new SulfurasUpdater();
                default:
                    return new RegularItemUpdater();
            }
        }
    }
}
