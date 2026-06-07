using UnityEngine;

public class Perk_SelfStunOnPlacement : APerkBase
{
	private int spawnCount;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	private void StunTower(Vector3 position, ABaseTower excludeTower = null)
	{
	}
}
