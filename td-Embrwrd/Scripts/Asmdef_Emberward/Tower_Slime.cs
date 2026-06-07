using System.Collections.Generic;
using UnityEngine;

public class Tower_Slime : ADirectionalTower
{
	[SerializeField]
	private float baseAttackRange;

	[SerializeField]
	private GameObject prefab_Arrow;

	private List<AMonsterBase> list_MonstersInArea;

	private Vector3 baseParticleScale;

	private int maxSlimeBombCount;

	private List<Obj_SlimeBomb> list_CreatedSlimeBombs;

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
