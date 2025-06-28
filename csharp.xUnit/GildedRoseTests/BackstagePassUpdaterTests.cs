using Xunit;
using GildedRoseKata;

public class BackstagePassUpdaterTests
{
    [Fact]
    public void Quality_IncreasesByOne_WhenSellInAboveTen()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
        var inventoryItem = new InventoryItem(item);
        var updater = new BackstagePassUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(14, item.SellIn);
        Assert.Equal(21, item.Quality);
    }

    [Fact]
    public void Quality_IncreasesByTwo_WhenSellInBetweenSixAndTen()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 };
        var inventoryItem = new InventoryItem(item);
        var updater = new BackstagePassUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(9, item.SellIn);
        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void Quality_IncreasesByThree_WhenSellInBetweenOneAndFive()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 };
        var inventoryItem = new InventoryItem(item);
        var updater = new BackstagePassUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(23, item.Quality);
    }

    [Fact]
    public void Quality_DropsToZero_AfterConcert()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
        var inventoryItem = new InventoryItem(item);
        var updater = new BackstagePassUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void Quality_DoesNotExceedFifty()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 };
        var inventoryItem = new InventoryItem(item);
        var updater = new BackstagePassUpdater();

        updater.Update(inventoryItem);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(50, item.Quality); // Should not exceed 50
    }
}
