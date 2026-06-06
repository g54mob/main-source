using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class BeverageMetadataEntry
	{
		public int metadataId;

		public string ownerSaveableId;

		public int slotIndex;

		public string baseType;

		public string catalyst1Id;

		public string catalyst2Id;

		public string catalyst3Id;

		public int qualityBonus;

		public int combinedTags;

		public float calculatedPrice;

		public int bottleCount;
	}
}
