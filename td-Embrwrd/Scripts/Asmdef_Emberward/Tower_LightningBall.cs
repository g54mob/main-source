using System.Collections.Generic;
using UnityEngine;

public class Tower_LightningBall : ADirectionalTower
{
	[SerializeField]
	private float baseAttackRange;

	private List<AMonsterBase> list_MonstersInArea;

	private float instantShootCooldown;

	protected override void CannonUpdateProc()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	public void TriggerInstantShoot()
	{
	}

	protected override void ShootProc()
	{
	}
}
