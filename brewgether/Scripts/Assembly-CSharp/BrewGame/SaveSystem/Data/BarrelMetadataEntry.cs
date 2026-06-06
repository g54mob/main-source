using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class BarrelMetadataEntry
	{
		public int metadataId;

		public string ownerSaveableId;

		public int slotIndex;

		public int beverageType;

		public int barrelState;

		public int remainingBottles;

		public long fermentationStartTime;

		public long agingStartTime;

		public int qualityBonus;
	}
}
