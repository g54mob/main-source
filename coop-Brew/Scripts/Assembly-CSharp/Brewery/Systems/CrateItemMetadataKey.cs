using System;

namespace Brewery.Systems
{
	[Serializable]
	public struct CrateItemMetadataKey : IEquatable<CrateItemMetadataKey>
	{
		public ulong ownerId;

		public int containerSlot;

		public InventoryType inventoryType;

		public int itemSlotInCrate;

		public CrateItemMetadataKey(ulong ownerId, int containerSlot, InventoryType inventoryType, int itemSlotInCrate)
		{
			this.ownerId = 0uL;
			this.containerSlot = 0;
			this.inventoryType = default(InventoryType);
			this.itemSlotInCrate = 0;
		}

		public bool Equals(CrateItemMetadataKey other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
