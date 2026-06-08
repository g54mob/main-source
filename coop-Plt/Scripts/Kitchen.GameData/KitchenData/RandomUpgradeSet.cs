using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "UpgradeSet", menuName = "Kitchen/Upgrades/Set")]
	public class RandomUpgradeSet : GameDataObject
	{
		public UpgradeRewardTier Tier;

		public List<IUpgrade> Rewards;

		public static UpgradeRewardTier GetTierForDay(int day)
		{
			if (day > 15)
			{
				return UpgradeRewardTier.High;
			}
			if (day > 7)
			{
				return UpgradeRewardTier.Medium;
			}
			if (day > 1)
			{
				return UpgradeRewardTier.Low;
			}
			return UpgradeRewardTier.Failure;
		}

		protected override void InitialiseDefaults()
		{
			Rewards = new List<IUpgrade>();
		}

		public override void SetupForGame()
		{
			if (Rewards == null)
			{
				Rewards = new List<IUpgrade>();
			}
		}
	}
}
