using System.Collections.Generic;
using UnityEngine;

public class Tower_FrostRay : ADirectionalTower
{
	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private ParticleSystem particle_Hit;

	[SerializeField]
	private ParticleSystem particle_Emit;

	[SerializeField]
	private float upgradeB_ExplosionRange;

	private List<AMonsterBase> list_MonstersInArea;

	private float updateTargetInterval;

	private float updateTargetTimer;

	protected override void CannonSpawnProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void ShootProc()
	{
	}
}
