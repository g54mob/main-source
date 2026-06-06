using System;
using Unity.Collections;
using Unity.Netcode;

namespace Port
{
	[Serializable]
	public struct PortContract : INetworkSerializable, IEquatable<PortContract>
	{
		public int ContractId;

		public int ShipId;

		public int RequiredDrinkType;

		public int RequiredDrinkTags;

		public FixedString64Bytes RequiredDrinkCatalyst1;

		public FixedString64Bytes RequiredDrinkCatalyst2;

		public FixedString64Bytes RequiredDrinkCatalyst3;

		public int RequiredDrinkQty;

		public int DeliveredDrinkQty;

		public FixedString64Bytes RequiredCatalystId1;

		public int RequiredCatalystQty1;

		public int DeliveredCatalystQty1;

		public FixedString64Bytes RequiredCatalystId2;

		public int RequiredCatalystQty2;

		public int DeliveredCatalystQty2;

		public int MaterialReward;

		public int ReputationReward;

		public int DeadlineDay;

		public float DeadlineHour;

		public PortContractStatus Status;

		public ulong AcceptedByClientId;

		public bool RequiresDrinks => false;

		public bool RequiresCatalyst1 => false;

		public bool RequiresCatalyst2 => false;

		public bool IsFullyDelivered => false;

		public int RemainingDrinks => 0;

		public int RemainingCatalyst1 => 0;

		public int RemainingCatalyst2 => 0;

		public bool MatchesDrink(int baseType, int combinedTags)
		{
			return false;
		}

		public int MatchesCatalyst(FixedString64Bytes catalystId)
		{
			return 0;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(PortContract other)
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

		public static bool operator ==(PortContract left, PortContract right)
		{
			return false;
		}

		public static bool operator !=(PortContract left, PortContract right)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
