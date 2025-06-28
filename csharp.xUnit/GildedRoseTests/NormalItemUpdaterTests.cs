using Xunit;
using GildedRoseKata;

public class NormalItemUpdaterTests
{
    [Fact]
    public void QualityAndSellIn_Decrease_ByOne_BeforeSellInDate()
    {
        var item = new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 10 };
        var inventoryItem = new InventoryItem(item);
        var updater = new NormalItemUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(9, item.Quality);
    }

    [Fact]
    public void Quality_DecreasesByTwo_AfterSellInDate()
    {
        var item = new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 10 };
        var inventoryItem = new InventoryItem(item);
        var updater = new NormalItemUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(8, item.Quality);
    }

    [Fact]
    public void Quality_NeverNegative()
    {
        var item = new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 0 };
        var inventoryItem = new InventoryItem(item);
        var updater = new NormalItemUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void Quality_NeverNegative_AfterSellInDate()
    {
        var item = new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 1 };
        var inventoryItem = new InventoryItem(item);
        var updater = new NormalItemUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }
}
