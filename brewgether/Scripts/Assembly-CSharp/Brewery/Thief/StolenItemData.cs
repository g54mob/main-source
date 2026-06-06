using System;
using System.Collections.Generic;
using Brewery.Items;
using InventorySystem;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Thief
{
	[Serializable]
	public struct StolenItemData : INetworkSerializable, IEquatable<StolenItemData>
	{
		public FixedString64Bytes itemId;

		public int quantity;

		public ulong sourceStorageId;

		public int sourceSlotIndex;

		public float stolenTimestamp;

		public ulong thiefId;

		public FixedString512Bytes beverageMetadataJson;

		public FixedString512Bytes barrelMetadataJson;

		public FixedString512Bytes crateMetadataJson;

		public FixedString512Bytes crateItemBeverageMetadataJson;

		public FixedString512Bytes crateItemBarrelMetadataJson;

		public float estimatedValue;

		public bool IsExpired => false;

		public float HoursUntilExpired => 0f;

		public bool HasBeverageMetadata => false;

		public bool HasBarrelMetadata => false;

		public bool HasCrateMetadata => false;

		public bool HasCrateItemBeverageMetadata => false;

		public bool HasCrateItemBarrelMetadata => false;

		public static StolenItemData FromSlot(InventorySlot slot, int quantity, ulong sourceStorageId, int sourceSlotIndex, ulong thiefId)
		{
			return default(StolenItemData);
		}

		private static float CalculateEstimatedValue(Item item, int quantity)
		{
			return 0f;
		}

		private static string SerializeCrateItemBeverageMetadata(Dictionary<int, BeerDataSnapshot> dict)
		{
			return null;
		}

		public static Dictionary<int, BeerDataSnapshot> DeserializeCrateItemBeverageMetadata(string json)
		{
			return null;
		}

		private static string SerializeCrateItemBarrelMetadata(Dictionary<int, BarrelMetadata> dict)
		{
			return null;
		}

		public static Dictionary<int, BarrelMetadata> DeserializeCrateItemBarrelMetadata(string json)
		{
			return null;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(StolenItemData other)
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

		public static bool operator ==(StolenItemData left, StolenItemData right)
		{
			return false;
		}

		public static bool operator !=(StolenItemData left, StolenItemData right)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
