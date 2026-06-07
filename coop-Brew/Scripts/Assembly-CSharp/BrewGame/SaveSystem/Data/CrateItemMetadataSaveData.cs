using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class CrateItemMetadataSaveData
	{
		public int crateSlot;

		public string type;

		public BeverageMetadataSaveData beverageData;

		public BarrelMetadataSaveData barrelData;
	}
}
