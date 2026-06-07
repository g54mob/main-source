using System.Collections.Generic;
using InventorySystem;

namespace Brewery.Stations
{
	public static class StationMetadataHelper
	{
		public static ulong ResolveInventoryOwnerClientId(InventoryManager inventory)
		{
			return 0uL;
		}

		public static int FindSlotForItem(InventoryManager inventory, Item item)
		{
			return 0;
		}

		public static Dictionary<int, int> CaptureItemQuantities(InventoryManager inventory, Item item)
		{
			return null;
		}

		public static int FindNewItemSlot(InventoryManager inventory, Item item, Dictionary<int, int> beforeSnapshot)
		{
			return 0;
		}
	}
}
