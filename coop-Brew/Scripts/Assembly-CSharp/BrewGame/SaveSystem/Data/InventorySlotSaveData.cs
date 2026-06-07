using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class InventorySlotSaveData
	{
		public string itemId;

		public string itemName;

		public int quantity;

		public int metadataIndex;

		public BeverageMetadataSaveData beverageMetadata;

		public BarrelMetadataSaveData barrelMetadata;

		public CrateMetadataSaveData crateMetadata;

		public List<CrateItemMetadataSaveData> crateItemsMetadata;

		public bool IsEmpty => false;

		public InventorySlotSaveData()
		{
		}

		public InventorySlotSaveData(string itemId, string itemName, int quantity)
		{
		}
	}
}
