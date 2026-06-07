using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class CatalystPlayerStatsSaveData
	{
		public int totalBrewsMade;

		public int totalDiscoveries;

		public int legendaryBrewCount;

		public float bestPrice;

		public int favoriteCount;
	}
}
