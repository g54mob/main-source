using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.NPC.TradingSystem
{
	[Serializable]
	public struct CatalystUsedEntry : INetworkSerializable, IEquatable<CatalystUsedEntry>
	{
		public FixedString32Bytes CatalystId;

		public int UsedToday;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(CatalystUsedEntry other)
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
