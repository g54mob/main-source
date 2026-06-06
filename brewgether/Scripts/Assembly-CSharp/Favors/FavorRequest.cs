using System;
using Unity.Collections;
using Unity.Netcode;

namespace Favors
{
	[Serializable]
	public struct FavorRequest : INetworkSerializable, IEquatable<FavorRequest>
	{
		public int FavorId;

		public FixedString64Bytes NpcId;

		public FixedString64Bytes HouseId;

		public FixedString64Bytes NPCName;

		public FixedString64Bytes RequestedItemId;

		public FixedString128Bytes RequestedItemName;

		public int QuantityRequested;

		public FavorRewardType RewardType;

		public int RewardAmount;

		public FixedString64Bytes RewardFurnitureId;

		public FixedString64Bytes RewardFurnitureName;

		public float CreatedTime;

		public float ExpiryDuration;

		public FavorStatus Status;

		public ulong AcceptedByClientId;

		public bool IsExpired => false;

		public float RemainingTime => 0f;

		public bool CanAccept(ulong clientId)
		{
			return false;
		}

		public bool IsActiveFor(ulong clientId)
		{
			return false;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(FavorRequest other)
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

		public static bool operator ==(FavorRequest left, FavorRequest right)
		{
			return false;
		}

		public static bool operator !=(FavorRequest left, FavorRequest right)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
