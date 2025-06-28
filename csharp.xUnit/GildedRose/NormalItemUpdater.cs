namespace GildedRoseKata;

public class NormalItemUpdater : IItemUpdater
{
    public void Update(InventoryItem inventoryItem)
    {
        var item = inventoryItem.Item;
        if (item.Quality > 0) item.Quality--;
        item.SellIn--;
        if (item.SellIn < 0 && item.Quality > 0) item.Quality--;
    }
}

public class AgedBrieUpdater : IItemUpdater
{
    public void Update(InventoryItem inventoryItem)
    {
        var item = inventoryItem.Item;
        if (item.Quality < 50) item.Quality++;
        item.SellIn--;
        if (item.SellIn < 0 && item.Quality < 50) item.Quality++;
    }
}

public class BackstagePassUpdater : IItemUpdater
{
    public void Update(InventoryItem inventoryItem)
    {
        var item = inventoryItem.Item;
        if (item.Quality < 50) item.Quality++;
        if (item.SellIn < 11 && item.Quality < 50) item.Quality++;
        if (item.SellIn < 6 && item.Quality < 50) item.Quality++;
        item.SellIn--;
        if (item.SellIn < 0) item.Quality = 0;
    }
}

public class SulfurasUpdater : IItemUpdater
{
    public void Update(InventoryItem inventoryItem)
    {
        // Legendary item, no update needed
    }
}
