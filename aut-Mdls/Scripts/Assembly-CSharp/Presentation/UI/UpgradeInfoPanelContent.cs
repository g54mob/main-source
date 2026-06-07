using Events.UI;
using UnityEngine;

namespace Presentation.UI
{
	public class UpgradeInfoPanelContent : InfoPanelContent
	{
		[SerializeField]
		private ResourceCost _upgradeCost;

		[SerializeField]
		private string _upgradeLevelCurrent;

		[SerializeField]
		private string _upgradeLevelNew;

		[SerializeField]
		private Sprite _rewardSprite;

		[SerializeField]
		private string _rewardDescription;

		[SerializeField]
		private bool _showLevelUpIcon = true;

		private bool _hasOutput = true;

		public void UpdateContent(ResourceCost cost, string upgradeLevelCurrent, string upgradeLevelNew, bool hasOutput, Sprite rewardSprite, string rewardDescription, bool showLevelUpIcon = true)
		{
			_upgradeCost = cost;
			_upgradeLevelCurrent = upgradeLevelCurrent;
			_upgradeLevelNew = upgradeLevelNew;
			_rewardSprite = rewardSprite;
			_rewardDescription = rewardDescription;
			_showLevelUpIcon = showLevelUpIcon;
			_hasOutput = hasOutput;
		}

		protected override InfoPanelDto GetInfoPanelDto()
		{
			return new UpgradeInfoPanelDto(_upgradeCost, _upgradeLevelCurrent, _upgradeLevelNew, _hasOutput, _rewardSprite, _rewardDescription, _showLevelUpIcon);
		}
	}
}
