using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Stations
{
	[Serializable]
	public struct StationSlotData : INetworkSerializable, IEquatable<StationSlotData>
	{
		public FixedString64Bytes itemId;

		public int quantity;

		public bool IsEmpty => false;

		public static StationSlotData Empty => default(StationSlotData);

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(StationSlotData other)
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
