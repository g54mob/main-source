using Brewery.Items;
using InventorySystem;

namespace Brewery.Systems
{
	public static class CrateInventoryHelper
	{
		public static InventorySlot[] GetCrateContents(ulong ownerId, int crateSlotIndex, InventoryType inventoryType)
		{
			return null;
		}

		public static InventorySlot[] CreateEmptySlotArray()
		{
			return null;
		}

		public static InventorySlot[] MetadataToSlots(CrateMetadata metadata)
		{
			return null;
		}

		public static CrateMetadata SlotsToMetadata(InventorySlot[] slots)
		{
			return default(CrateMetadata);
		}

		public static int GetTotalItemCount(CrateMetadata metadata)
		{
			return 0;
		}

		public static bool CanAddItemToCrate(CrateMetadata metadata, Item item, int quantity, CrateItem crateItem)
		{
			return false;
		}

		private static bool CrateExclusivityCheck(CrateMetadata metadata, Item newItem)
		{
			return false;
		}

		public static int GetMaxAddable(CrateMetadata metadata, Item item, CrateItem crateItem)
		{
			return 0;
		}
	}
}
