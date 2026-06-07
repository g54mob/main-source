using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class CatalystDiscoveryEntry
	{
		public int discoveryHash;

		public string baseType;

		public string catalyst1Id;

		public string catalyst2Id;

		public string catalyst3Id;

		public int timesCreated;

		public float bestPrice;

		public long firstDiscoveryTimestamp;

		public bool isFavorite;
	}
}
