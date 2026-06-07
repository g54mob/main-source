using System;

namespace VampireSurvivors.Data.PowerUp
{
	[Serializable]
	public class PowerUpData
	{
		public int level { get; set; }

		public bool hidden { get; set; }

		public string bulletType { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public string texture { get; set; }

		public string frameName { get; set; }

		public bool isPowerUp { get; set; }

		public bool isAnUnlockable { get; set; }

		public int price { get; set; }

		public int unlockedRank { get; set; }

		public bool isSpecial { get; set; }

		public bool specialBG { get; set; }

		private string GetPrefix(PowerUpType type)
		{
			return null;
		}

		public string GetLocalizedName(PowerUpType type)
		{
			return null;
		}

		public string GetLocalizedDescription(PowerUpType type)
		{
			return null;
		}
	}
}
