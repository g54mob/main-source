using System;
using Brewery.Core;
using Brewery.Data;
using Unity.Netcode;

namespace Brewery.Items
{
	[Serializable]
	public struct BeerDataSnapshot : INetworkSerializable
	{
		public bool isValid;

		public string generatedName;

		public BaseType baseType;

		public BrewTag combinedTags;

		public int batchUnits;

		public float bestPrice;

		public FactionType bestFaction;

		public bool isLegendary;

		public string legendaryName;

		public string catalyst1Id;

		public string catalyst2Id;

		public string catalyst3Id;

		public float baseValue;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public static BeerDataSnapshot CreateDefault()
		{
			return default(BeerDataSnapshot);
		}

		public static BeerDataSnapshot FromBrewingResult(BrewingResult result)
		{
			return default(BeerDataSnapshot);
		}

		private static BeerDataSnapshot CreateBase(BrewingResult result)
		{
			return default(BeerDataSnapshot);
		}

		public string ToJson()
		{
			return null;
		}

		public static BeerDataSnapshot? FromJson(string json)
		{
			return null;
		}
	}
}
