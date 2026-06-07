using System;
using Unity.Collections;
using Unity.Netcode;

namespace Property
{
	public struct HouseOwnership : INetworkSerializable, IEquatable<HouseOwnership>
	{
		public FixedString64Bytes houseId;

		public ulong ownerId;

		public bool isOccupiedByResident;

		public FixedString64Bytes residentNpcId;

		public int negotiatedDailyRent;

		public double rentStartRealTime;

		public double lastCollectedRealTime;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(HouseOwnership other)
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
