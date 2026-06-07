using System.Collections.Generic;

public class TooltipComponent_towerUpgrade : TooltipComponent
{
	public struct FTowerUpgradeTooltipData
	{
		public GameplayObjectData towerData;

		public Tower upgradingTower;

		public FTowerUpgradeTooltipData(GameplayObjectData towerData, Tower upgradingTower)
		{
			this.towerData = towerData;
			this.upgradingTower = upgradingTower;
		}
	}

	protected override Dictionary<string, object> GetData()
	{
		TowerUpgradeElementUI component = GetComponent<TowerUpgradeElementUI>();
		FTowerUpgradeTooltipData fTowerUpgradeTooltipData = new FTowerUpgradeTooltipData(component.TowerData, component.Tower);
		return new Dictionary<string, object> { { "towerUpgradeData", fTowerUpgradeTooltipData } };
	}
}
