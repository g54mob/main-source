using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class CrateMetadataEntry
	{
		public int metadataId;

		public string ownerSaveableId;

		public int slotIndex;

		public List<InventorySlotSaveData> contents;
	}
}
