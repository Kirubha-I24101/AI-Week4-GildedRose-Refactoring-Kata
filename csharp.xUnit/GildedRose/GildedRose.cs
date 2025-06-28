using System;
using System.Collections.Generic;

namespace GildedRoseKata;

/// <summary>
/// GildedRose Service
/// </summary>
///
/// <para>
/// <b>Overview</b><br/>
/// The <c>GildedRose</c> class is the core service responsible for managing and updating the quality and sell-in values of a collection of inventory items in accordance with the Gilded Rose requirements.
/// </para>
/// <para>
/// <b>Key Features and Capabilities</b>
/// <list type="bullet">
///   <item>Encapsulates inventory item management and update logic.</item>
///   <item>Supports multiple item types (Normal, Aged Brie, Backstage Pass, Sulfuras) with type-specific update rules.</item>
///   <item>Ensures robust input validation and error handling.</item>
/// </list>
/// </para>
/// <para>
/// <b>Usage Patterns and Examples</b><br/>
/// Instantiate <c>GildedRose</c> with a list of <see cref="Item"/> objects, then call <see cref="UpdateQuality"/> to apply daily updates.
/// </para>
/// <para>
/// <b>Dependencies and Requirements</b>
/// <list type="bullet">
///   <item>Requires .NET 8 or later.</item>
///   <item>Depends on <see cref="Item"/>, <see cref="InventoryItem"/>, <see cref="ItemType"/>, and <c>ItemUpdaterFactory</c> (not shown).</item>
/// </list>
/// </para>
public class GildedRose
{
    /// <summary>
    /// Internal list of inventory items managed by this service.
    /// </summary>
    private readonly IList<InventoryItem> Items;

    /// <summary>
    /// Initializes a new instance of the <see cref="GildedRose"/> class.
    /// </summary>
    /// <param name="items">
    /// The list of <see cref="Item"/> objects to be managed and updated.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="items"/> is <c>null</c>.
    /// </exception>
    /// <example>
    /// <code>
    /// var items = new List&lt;Item&gt; { new Item { Name = "foo", SellIn = 10, Quality = 20 } };
    /// var app = new GildedRose(items);
    /// </code>
    /// </example>
    public GildedRose(IList<Item> items)
    {
        if (items is null) throw new ArgumentNullException(nameof(items));
        Items = new List<InventoryItem>();
        foreach (var item in items)
            Items.Add(new InventoryItem(item));
    }

    /// <summary>
    /// Updates the quality and sell-in values of all managed inventory items according to their type-specific rules.
    /// </summary>
    /// <remarks>
    /// This method delegates update logic to the appropriate updater for each item type.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if an item type is not supported by the updater factory.
    /// </exception>
    /// <example>
    /// <code>
    /// var items = new List&lt;Item&gt; { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
    /// var app = new GildedRose(items);
    /// app.UpdateQuality();
    /// </code>
    /// </example>
    public void UpdateQuality()
    {
        foreach (var inventoryItem in Items)
        {
            var updater = ItemUpdaterFactory.GetUpdater(inventoryItem.Type);
            updater.Update(inventoryItem);
        }
    }
}
