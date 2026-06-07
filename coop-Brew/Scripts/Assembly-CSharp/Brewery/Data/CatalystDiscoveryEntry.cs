using System;
using Brewery.Core;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Data
{
	[Serializable]
	public struct CatalystDiscoveryEntry : INetworkSerializable, IEquatable<CatalystDiscoveryEntry>
	{
		public int discoveryId;

		public BaseType baseType;

		public FixedString32Bytes catalyst1Id;

		public FixedString32Bytes catalyst2Id;

		public FixedString32Bytes catalyst3Id;

		public bool isDiscovered;

		public double firstDiscoveredTime;

		public FixedString128Bytes discoveredName;

		public BrewTag discoveredTags;

		public bool isLegendary;

		public int timesCreated;

		public float bestPrice;

		public FactionType bestFaction;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(CatalystDiscoveryEntry other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public string GetCatalystSummary()
		{
			return null;
		}
	}
}
