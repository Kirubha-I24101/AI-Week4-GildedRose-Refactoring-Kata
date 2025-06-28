namespace GildedRoseKata;

public class InventoryItem
{
    public Item Item { get; }
    public ItemType Type { get; }

    public InventoryItem(Item item)
    {
        Item = item;
        Type = item.Name switch
        {
            "Aged Brie" => ItemType.AgedBrie,
            "Backstage passes to a TAFKAL80ETC concert" => ItemType.BackstagePass,
            "Sulfuras, Hand of Ragnaros" => ItemType.Sulfuras,
            _ => ItemType.Normal
        };
    }
}
