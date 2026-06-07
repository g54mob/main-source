using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class CatalystBrewRecordEntry
	{
		public int discoveryHash;

		public long timestamp;

		public float price;

		public string baseType;

		public string catalyst1Id;

		public string catalyst2Id;

		public string catalyst3Id;
	}
}
