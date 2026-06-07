using System;
using System.Collections.Generic;

public class Perk_TowerSpeedDownDamageUp : APerkBase
{
	[Serializable]
	private class TowerRoundCount
	{
		public ABaseTower tower;

		public int roundCount;
	}

	private List<TowerRoundCount> towerRoundCounts;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRoundEnd()
	{
	}
}
