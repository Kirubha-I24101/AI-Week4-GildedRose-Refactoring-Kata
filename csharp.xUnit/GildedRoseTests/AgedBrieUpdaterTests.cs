using Xunit;
using GildedRoseKata;

public class AgedBrieUpdaterTests
{
    [Fact]
    public void Quality_IncreasesByOne_BeforeSellIn()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 10 };
        var inventoryItem = new InventoryItem(item);
        var updater = new AgedBrieUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(1, item.SellIn);
        Assert.Equal(11, item.Quality);
    }

    [Fact]
    public void Quality_IncreasesByTwo_AfterSellIn()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 };
        var inventoryItem = new InventoryItem(item);
        var updater = new AgedBrieUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(12, item.Quality);
    }

    [Fact]
    public void Quality_DoesNotExceedFifty()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 };
        var inventoryItem = new InventoryItem(item);
        var updater = new AgedBrieUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(0, item.SellIn);
        Assert.Equal(50, item.Quality);
    }
}
