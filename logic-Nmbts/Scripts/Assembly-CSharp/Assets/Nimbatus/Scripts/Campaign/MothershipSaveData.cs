using System;
using System.Collections.Generic;

namespace Assets.Nimbatus.Scripts.Campaign
{
	[Serializable]
	public class MothershipSaveData
	{
		public int Health;

		public int MaxHealth;

		public int Repairs;

		public List<MothershipUpgradeData> Upgrades;
	}
}
