using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Shop
{
	[Serializable]
	public struct ShopMetadata : INetworkSerializable, IEquatable<ShopMetadata>
	{
		public const int MAX_GRID_SLOTS = 100;

		public FixedString64Bytes[] itemIds;

		public int[] quantities;

		public int gridSize;

		public static ShopMetadata CreateEmpty(int gridSize)
		{
			return default(ShopMetadata);
		}

		public bool IsEmpty()
		{
			return false;
		}

		public int GetTotalItemCount()
		{
			return 0;
		}

		public int GetOccupiedSlotCount()
		{
			return 0;
		}

		public void SetSlot(int slotIndex, string itemId, int quantity)
		{
		}

		public void ClearSlot(int slotIndex)
		{
		}

		public string GetItemId(int slotIndex)
		{
			return null;
		}

		public int GetQuantity(int slotIndex)
		{
			return 0;
		}

		public int FindEmptySlot()
		{
			return 0;
		}

		public int FindStackableSlot(string itemId, int maxStackSize)
		{
			return 0;
		}

		public bool IsValid()
		{
			return false;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(ShopMetadata other)
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
