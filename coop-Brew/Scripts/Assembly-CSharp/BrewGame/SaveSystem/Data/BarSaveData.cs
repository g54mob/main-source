using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class BarSaveData
	{
		public int barIndex;

		public bool isOwned;

		public int upgradeLevel;

		public List<InventorySlotSaveData> inventory;

		public float accumulatedMoney;

		public bool isOperational;

		public List<int> destroyedObjectIndices;

		public List<int> destroyedGraffitiIndices;

		public List<int> graffitiPrefabIndices;

		public List<float> objectHealthValues;

		public string factionAttractionData;
	}
}
