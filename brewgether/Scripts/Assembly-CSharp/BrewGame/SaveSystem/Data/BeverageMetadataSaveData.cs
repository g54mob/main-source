using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class BeverageMetadataSaveData
	{
		public bool isValid;

		public string generatedName;

		public int baseType;

		public int combinedTags;

		public int batchUnits;

		public float bestPrice;

		public int bestFaction;

		public bool isLegendary;

		public string legendaryName;

		public string catalyst1Id;

		public string catalyst2Id;

		public string catalyst3Id;

		public float baseValue;
	}
}
