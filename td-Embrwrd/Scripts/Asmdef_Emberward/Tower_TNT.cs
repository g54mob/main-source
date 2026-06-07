using System.Collections.Generic;
using UnityEngine;

public class Tower_TNT : ABaseTower
{
	[SerializeField]
	private List<Collider> list_CollisionColliders;

	[SerializeField]
	private GameObject node_FakeBullet;

	private Vector3 headModelForward;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void CannonDespawnProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	protected override void ShootProc()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}
}
