using System.Collections.Generic;

public class Relic_ElementMaster : RelicTemplate_TowerBased
{
	private List<eDamageType> towerTypes;

	private bool isEffectOn;

	private int guid;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnTowerElementChanged(ABaseTower tower, eDamageType type)
	{
	}

	private void OnTowerUpgrade(ABaseTower tower, ABaseTower.eUpgradeType upgradeType)
	{
	}

	private void OnTowerRemoved(ABaseTower tower)
	{
	}

	protected override void OnTowerPlacedProc(ABaseTower tower)
	{
	}

	protected override void OnTowerSoldProc(ABaseTower tower)
	{
	}

	protected void UpdateEffect()
	{
	}

	public override string ExtraTooltip()
	{
		return null;
	}
}
