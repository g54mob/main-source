using UnityEngine;

namespace Events.UI
{
	public class UpgradeInfoPanelDto : InfoPanelDto
	{
		public ResourceCost UpgradeCost;

		public bool CanAfford;

		public string UpgradeLevelCurrent;

		public string UpgradeLevelNew;

		public Sprite RewardSprite;

		public string RewardDescription;

		public bool ShowLevelUpIcon;

		public bool HasOutput;

		public UpgradeInfoPanelDto(ResourceCost upgradeCost, string upgradeLevelCurrent, string upgradeLevelNew, bool hasOutput, Sprite rewardSprite, string rewardDescription, bool showLevelUpIcon = true)
		{
			UpgradeCost = upgradeCost;
			UpgradeLevelCurrent = upgradeLevelCurrent;
			UpgradeLevelNew = upgradeLevelNew;
			RewardSprite = rewardSprite;
			RewardDescription = rewardDescription;
			ShowLevelUpIcon = showLevelUpIcon;
			HasOutput = hasOutput;
		}
	}
}
