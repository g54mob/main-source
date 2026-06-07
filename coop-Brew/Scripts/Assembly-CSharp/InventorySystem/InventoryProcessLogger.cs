using System.Collections.Generic;
using System.Text;
using Brewery.Items;
using Brewery.Systems;

namespace InventorySystem
{
	public static class InventoryProcessLogger
	{
		public static bool Enabled;

		private const string TAG = "[InventoryProcess]";

		public static void LogItemAdded(string inventoryType, ulong ownerId, int slotIndex, Item item, int quantity, BeerDataSnapshot? beverage = null, BarrelMetadata? barrel = null, CrateMetadata? crate = null, Dictionary<int, BeerDataSnapshot> crateBeverages = null, Dictionary<int, BarrelMetadata> crateBarrels = null)
		{
		}

		public static void LogItemAdded(string inventoryType, ulong ownerId, int slotIndex, InventorySlot slot)
		{
		}

		public static void LogItemRemoved(string inventoryType, ulong ownerId, int slotIndex, Item item, int quantity, BeerDataSnapshot? beverage = null, BarrelMetadata? barrel = null, CrateMetadata? crate = null, Dictionary<int, BeerDataSnapshot> crateBeverages = null, Dictionary<int, BarrelMetadata> crateBarrels = null)
		{
		}

		public static void LogItemRemoved(string inventoryType, ulong ownerId, int slotIndex, InventorySlot slot)
		{
		}

		public static void LogRpcCall(string rpcName, string direction, ulong clientId, string details)
		{
		}

		public static void LogTransfer(string sourceInventory, ulong sourceOwner, int sourceSlot, string destInventory, ulong destOwner, int destSlot, Item item, int quantity)
		{
		}

		private static void AppendMetadata(StringBuilder sb, Item item, BeerDataSnapshot? beverage, BarrelMetadata? barrel, CrateMetadata? crate, Dictionary<int, BeerDataSnapshot> crateBeverages, Dictionary<int, BarrelMetadata> crateBarrels)
		{
		}

		public static string FormatBeverageMetadata(BeerDataSnapshot data, string indent = "")
		{
			return null;
		}

		public static string FormatBarrelMetadata(BarrelMetadata data, string indent = "")
		{
			return null;
		}

		public static string FormatCrateMetadata(CrateMetadata data, Dictionary<int, BeerDataSnapshot> beverages, Dictionary<int, BarrelMetadata> barrels, string indent = "")
		{
			return null;
		}

		public static BarrelMetadata? GetBarrelMetadataIfExists(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
			return null;
		}

		public static CrateMetadata? GetCrateMetadataIfExists(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
			return null;
		}

		public static Dictionary<int, BeerDataSnapshot> GetCrateItemBeverageMetadata(ulong ownerId, int crateSlot, InventoryType inventoryType)
		{
			return null;
		}

		public static Dictionary<int, BarrelMetadata> GetCrateItemBarrelMetadata(ulong ownerId, int crateSlot, InventoryType inventoryType)
		{
			return null;
		}

		public static void CaptureAndLogRemoval(string inventoryType, ulong ownerId, int slotIndex, InventoryType invType, InventorySlot slot)
		{
		}

		public static void CaptureAndLogRemoval(string inventoryType, ulong ownerId, int slotIndex, InventoryType invType, Item item, int quantity)
		{
		}

		public static void CaptureAndLogAddition(string inventoryType, ulong ownerId, int slotIndex, InventoryType invType, InventorySlot slot)
		{
		}

		public static void CaptureAndLogAddition(string inventoryType, ulong ownerId, int slotIndex, InventoryType invType, Item item, int quantity)
		{
		}
	}
}
