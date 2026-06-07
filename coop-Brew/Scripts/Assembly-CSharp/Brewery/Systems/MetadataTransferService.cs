using Brewery.Items;
using InventorySystem;

namespace Brewery.Systems
{
	public static class MetadataTransferService
	{
		public static void TransferMetadata(ulong sourceOwnerId, int sourceSlot, InventoryType sourceType, ulong targetOwnerId, int targetSlot, InventoryType targetType, Item item, bool showDebugLogs = false)
		{
		}

		public static void SetAndSyncCrateMetadata(ulong ownerId, int slot, InventoryType inventoryType, CrateMetadata metadata, bool showDebugLogs = false)
		{
		}

		public static void SetAndSyncBarrelMetadata(ulong ownerId, int slot, InventoryType inventoryType, BarrelMetadata metadata, bool showDebugLogs = false)
		{
		}

		public static void RemoveAndNotify(ulong ownerId, int slot, InventoryType inventoryType, Item item, bool showDebugLogs = false)
		{
		}

		public static MetadataSnapshot CaptureMetadata(ulong ownerId, int slot, InventoryType inventoryType, Item item, bool showDebugLogs = false)
		{
			return null;
		}

		public static void ApplyAndSyncMetadata(MetadataSnapshot snapshot, ulong targetOwnerId, int targetSlot, InventoryType targetInventoryType, bool showDebugLogs = false)
		{
		}

		public static void ClearMetadata(ulong ownerId, int slot, InventoryType inventoryType, Item item, bool showDebugLogs = false)
		{
		}

		private static void TransferCrateMetadata(ulong sourceOwnerId, int sourceSlot, InventoryType sourceType, ulong targetOwnerId, int targetSlot, InventoryType targetType, bool showDebugLogs)
		{
		}

		private static void TransferBarrelMetadata(ulong sourceOwnerId, int sourceSlot, InventoryType sourceType, ulong targetOwnerId, int targetSlot, InventoryType targetType, bool showDebugLogs)
		{
		}
	}
}
