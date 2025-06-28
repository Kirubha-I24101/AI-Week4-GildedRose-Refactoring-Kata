namespace GildedRoseKata;

public static class ItemUpdaterFactory
{
    public static IItemUpdater GetUpdater(ItemType type) => type switch
    {
        ItemType.AgedBrie => new AgedBrieUpdater(),
        ItemType.BackstagePass => new BackstagePassUpdater(),
        ItemType.Sulfuras => new SulfurasUpdater(),
        _ => new NormalItemUpdater()
    };
}
