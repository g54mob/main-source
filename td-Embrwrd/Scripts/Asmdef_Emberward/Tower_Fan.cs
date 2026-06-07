using System.Collections.Generic;
using UnityEngine;

public class Tower_Fan : ADirectionalTower
{
	[SerializeField]
	private Spin spin_Fan;

	[SerializeField]
	private List<Transform> list_FanBladePositions;

	[SerializeField]
	private ParticleSystem particle_FanHitMonster;

	[SerializeField]
	private ParticleSystem particle_Wind_Normal;

	[SerializeField]
	private ParticleSystem particle_Wind_Reverse;

	[SerializeField]
	private GameObject node_ParticleForUpgradeB;

	private List<AMonsterBase> list_MonstersInArea_Detection;

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

	private float GetSpeedMultiplierBySize(AMonsterBase monster)
	{
		return 0f;
	}
}
