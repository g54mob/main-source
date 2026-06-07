using UnityEngine;

public class Obj_AncientTower_Basic : Obj_AncientTower_Base
{
	[SerializeField]
	private GameObject bulletPrefab;

	protected override void DespawnProc()
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void ShootProc(ABaseTower targetTower)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void ShowTooltipProc()
	{
	}

	protected override void HideTooltipProc()
	{
	}
}
