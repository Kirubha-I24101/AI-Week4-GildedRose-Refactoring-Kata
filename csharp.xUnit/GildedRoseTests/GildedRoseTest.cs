using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void NormalItem_QualityAndSellInDecrease()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(19, items[0].Quality);
    }

    [Fact]
    public void NormalItem_QualityNeverNegative()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void NormalItem_QualityDegradesTwiceAfterSellIn()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 2 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void AgedBrie_QualityIncreases()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(1, items[0].Quality);
        Assert.Equal(1, items[0].SellIn);
    }

    [Fact]
    public void AgedBrie_QualityNeverExceedsFifty()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void AgedBrie_QualityIncreasesTwiceAfterSellIn()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 48 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    [Fact]
    public void BackstagePass_QualityIncreasesByOneWhenSellInAboveTen()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(21, items[0].Quality);
        Assert.Equal(14, items[0].SellIn);
    }

    [Fact]
    public void BackstagePass_QualityIncreasesByTwoWhenSellInTenOrLess()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 45 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(47, items[0].Quality);
        Assert.Equal(9, items[0].SellIn);
    }

    [Fact]
    public void BackstagePass_QualityIncreasesByThreeWhenSellInFiveOrLess()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 47 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
        Assert.Equal(4, items[0].SellIn);
    }

    [Fact]
    public void BackstagePass_QualityDropsToZeroAfterConcert()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 40 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    [Fact]
    public void BackstagePass_QualityNeverExceedsFifty()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void Sulfuras_QualityAndSellInNeverChange()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].SellIn);
        Assert.Equal(80, items[0].Quality);
    }
}
