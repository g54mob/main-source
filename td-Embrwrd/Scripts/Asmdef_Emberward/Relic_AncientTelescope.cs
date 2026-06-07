using System.Collections.Generic;
using UnityEngine;

public class Relic_AncientTelescope : RelicTemplate_TowerBased
{
	private int id;

	private List<Vector3> list_Dirs;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void OnTowerPlacedProc(ABaseTower newTower)
	{
	}

	private void OnTowerRemoved(ABaseTower newTower)
	{
	}

	private void CheckTowers(List<ABaseTower> list_Towers)
	{
	}

	protected bool CheckHaveAnyTowersNear(Vector3 position, ABaseTower fromTower)
	{
		return false;
	}
}
