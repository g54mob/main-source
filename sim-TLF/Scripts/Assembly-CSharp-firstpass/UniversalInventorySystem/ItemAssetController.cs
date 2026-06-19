using System.Collections.Generic;

namespace UniversalInventorySystem
{
	public static class ItemAssetController
	{
		public static bool ContainsWNull(this List<Item> items, Item item)
		{
			if (item == null)
			{
				return true;
			}
			return items.Contains(item);
		}
	}
}
