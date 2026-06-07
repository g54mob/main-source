using System.Collections.Generic;

public class Perk_TowerShootProgressivelySlower : APerkBase
{
	private class TowerShootCount
	{
		public int ShotCount;

		public int EffectLevel;
	}

	private Dictionary<ABaseTower, TowerShootCount> list_TowerShootCounts;

	private List<ABaseTower> list_AffectedTowers;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnRoundEnd()
	{
	}

	private void OnTowerShoot(ABaseTower tower, AMonsterBase targetMonster)
	{
	}
}
