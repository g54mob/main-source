using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Bar
{
	[Serializable]
	public struct BarComplaint : INetworkSerializable, IEquatable<BarComplaint>
	{
		public ulong NpcNetworkId;

		public FixedString64Bytes NpcName;

		public FixedString64Bytes RuleName;

		public FixedString128Bytes Message;

		public float Timestamp;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(BarComplaint other)
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
