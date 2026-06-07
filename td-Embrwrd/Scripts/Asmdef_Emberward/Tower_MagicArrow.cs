using System.Collections.Generic;
using UnityEngine;

public class Tower_MagicArrow : ADirectionalTower
{
	[SerializeField]
	private float baseAttackRange;

	[SerializeField]
	private GameObject prefab_Arrow;

	private List<AMonsterBase> list_MonstersInArea;

	private Vector3 baseParticleScale;

	protected override void CannonSpawnProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void ShootProc()
	{
	}
}
