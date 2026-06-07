using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_AncientTower_Fireball : Obj_AncientTower_Base
{
	[SerializeField]
	private GameObject fireballPrefab;

	[SerializeField]
	private ParticleSystem particle_Shoot;

	[SerializeField]
	private ParticleSystem particle_Smoke;

	[SerializeField]
	private List<Spin> list_SpinCogs;

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

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void TowerActivateProc()
	{
	}

	protected override void TowerResetProc()
	{
	}

	protected override void ShowTooltipProc()
	{
	}

	protected override void HideTooltipProc()
	{
	}
}
