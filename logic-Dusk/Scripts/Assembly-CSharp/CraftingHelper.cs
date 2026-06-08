using System.Collections.Generic;
using System.Linq;

public class CraftingHelper
{
	private static List<ICraftableItem> _craftableCache;

	private static void LoadCraftableItems()
	{
		_craftableCache = new List<ICraftableItem>();
		_craftableCache.Add(new CraftableDroneUpgrade(DroneUpgradeFactory.UpgradeDefinitions.First((DroneUpgradeDefinition x) => x.Type == DroneUpgradeType.Gatherer).Name, 8, DroneUpgradeType.Gatherer));
		_craftableCache.Add(new CraftableDroneUpgrade(DroneUpgradeFactory.UpgradeDefinitions.First((DroneUpgradeDefinition x) => x.Type == DroneUpgradeType.Generator).Name, 8, DroneUpgradeType.Generator));
	}

	public static List<ICraftableItem> GetAllItems()
	{
		if (_craftableCache == null)
		{
			LoadCraftableItems();
		}
		return _craftableCache;
	}

	public static IInventoryItem CraftItem(ICraftableItem itemToCraft)
	{
		return DroneUpgradeFactory.CreateUpgradeInstance(itemToCraft.UpgradeType);
	}
}
