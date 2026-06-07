using UnityEngine;

public class Relic_SmithingMask : ARelicBase
{
	[SerializeField]
	private float damageMultiplier;

	[SerializeField]
	private float shootRateMultiplier;

	[SerializeField]
	private float critChanceBonus;

	private ABaseTower lastUpgradedTower;

	private int guid;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnTowerUpgrade(ABaseTower tower, ABaseTower.eUpgradeType upgradeType)
	{
	}

	private void OnTowerRemoved(ABaseTower tower)
	{
	}

	private void OnBuffedTowerDespawned(ABaseTower tower)
	{
	}

	private void ApplyBuffToTower(ABaseTower tower)
	{
	}

	private void ApplyModifier(ABaseTower tower, eStatType statType, eModifierType modifierType, float value)
	{
	}

	private void ClearBuffFromCurrentTower()
	{
	}

	private void RemoveBuffFromTower(ABaseTower tower)
	{
	}
}
