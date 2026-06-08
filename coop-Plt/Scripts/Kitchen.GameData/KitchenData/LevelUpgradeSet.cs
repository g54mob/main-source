using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "LevelUpgradeSet", menuName = "Kitchen/Upgrades/Level Set")]
	public class LevelUpgradeSet : GameDataObject
	{
		public List<LevelUpgrade> Upgrades;

		protected override void InitialiseDefaults()
		{
			Upgrades = new List<LevelUpgrade>();
		}

		public override void SetupForGame()
		{
			if (Upgrades == null)
			{
				Upgrades = new List<LevelUpgrade>();
			}
		}
	}
}
