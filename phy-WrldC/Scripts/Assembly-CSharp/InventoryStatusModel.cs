using System.Collections.Generic;

public class InventoryStatusModel
{
	private readonly Dictionary<Schematic, InventoryStatusItem> items;

	public InventoryStatusModel()
	{
		items = new Dictionary<Schematic, InventoryStatusItem>();
	}

	public void AddBlockItem(InventoryStatusItem inventoryStatusItem)
	{
		items.Add(inventoryStatusItem.Schematic, inventoryStatusItem);
	}

	public InventoryStatusItem GetBlockItem(Schematic schematic)
	{
		if (items.ContainsKey(schematic))
		{
			return items[schematic];
		}
		return new InventoryStatusItem(schematic, 0);
	}
}
