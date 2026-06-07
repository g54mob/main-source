using System;

namespace Brewery.Systems
{
	[Serializable]
	public struct MetadataKey : IEquatable<MetadataKey>
	{
		public ulong ownerId;

		public int slotIndex;

		public InventoryType inventoryType;

		public MetadataKey(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
			this.ownerId = 0uL;
			this.slotIndex = 0;
			this.inventoryType = default(InventoryType);
		}

		public bool Equals(MetadataKey other)
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
