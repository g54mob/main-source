using Brewery.Items;
using Brewery.Systems;
using InventorySystem;

namespace UI.Tooltip
{
	public struct TooltipContext
	{
		public Item Item;

		public int Quantity;

		public int SlotIndex;

		public BeerDataSnapshot? EmbeddedBeverageMetadata;

		public BarrelMetadata? EmbeddedBarrelMetadata;

		public GarbageMetadata? EmbeddedGarbageMetadata;

		public ulong OwnerNetworkObjectId;

		public InventoryType InventoryType;

		public bool IsCrateItem;

		public int CrateSlotIndex;

		public int ItemSlotInCrate;

		public bool RequiresRealtimeUpdate => false;

		public bool IsEmpty => false;

		public static TooltipContext FromSlot(InventorySlot slot, int slotIndex, ulong ownerNetworkObjectId, InventoryType inventoryType)
		{
			return default(TooltipContext);
		}

		public static TooltipContext FromCrateItem(Item item, int quantity, int crateSlotIndex, int itemSlotInCrate, ulong ownerNetworkObjectId, InventoryType inventoryType, BeerDataSnapshot? embeddedBeverageMetadata = null)
		{
			return default(TooltipContext);
		}
	}
}
