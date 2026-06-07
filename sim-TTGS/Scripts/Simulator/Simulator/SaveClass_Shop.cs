using System;
using System.Collections.Generic;
using Simulator.GameWorld;

namespace Simulator
{
	[Serializable]
	public class SaveClass_Shop
	{
		public bool shopOpen;

		public bool shopOpenThisDay;

		public List<int> shopClientQueue;

		public int shopExtensionLevel;

		public int reserveExtensionLevel;

		public string shopName;

		public List<BoxSaveState> simpleBoxes;

		public List<StackableBoxSaveState> stackableBoxes;

		public SaveClass_Shop()
		{
			shopOpen = false;
			shopOpenThisDay = false;
			shopClientQueue = new List<int>();
			shopExtensionLevel = ShopExtensionSettings.GetShopExtensionLevelFromMarketStoreLevel(0);
			reserveExtensionLevel = ShopExtensionSettings.GetReserveExtensionLevelFromMarketStoreLevel(0);
			shopName = ShopSettings.ShopName;
			simpleBoxes = new List<BoxSaveState>();
			stackableBoxes = new List<StackableBoxSaveState>();
		}

		public void SaveBoxes()
		{
			simpleBoxes.Clear();
			stackableBoxes.Clear();
			foreach (BoxSaveState item2 in BaseBox.GetBoxesToSave())
			{
				if (item2 is StackableBoxSaveState item)
				{
					stackableBoxes.Add(item);
				}
				else
				{
					simpleBoxes.Add(item2);
				}
			}
		}
	}
}
