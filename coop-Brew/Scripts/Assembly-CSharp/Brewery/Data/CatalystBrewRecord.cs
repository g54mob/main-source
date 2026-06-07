using System;
using Brewery.Core;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Data
{
	[Serializable]
	public struct CatalystBrewRecord : INetworkSerializable, IEquatable<CatalystBrewRecord>
	{
		public int recordId;

		public double timestamp;

		public BaseType baseType;

		public BrewTag combinedTags;

		public FixedString128Bytes generatedName;

		public FixedString32Bytes catalyst1Id;

		public FixedString32Bytes catalyst2Id;

		public FixedString32Bytes catalyst3Id;

		public float bestPrice;

		public FactionType bestFaction;

		public bool isLegendary;

		public FixedString64Bytes legendaryName;

		public bool isFavorite;

		public int timesCreated;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(CatalystBrewRecord other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public int GetDiscoveryId()
		{
			return 0;
		}

		public static int GenerateDiscoveryId(BaseType baseType, string cat1, string cat2, string cat3)
		{
			return 0;
		}

		public string GetCatalystSummary()
		{
			return null;
		}

		private static string FormatCatalystName(string id)
		{
			return null;
		}
	}
}
