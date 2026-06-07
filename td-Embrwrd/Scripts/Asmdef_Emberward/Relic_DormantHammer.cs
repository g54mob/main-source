using System.Collections.Generic;

public class Relic_DormantHammer : RelicTemplate_TowerBased
{
	private List<eItemType> towerBuildThisRound;

	private Dictionary<eItemType, int> dic_DormantRecord;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRoundEnd()
	{
	}

	protected override void OnTowerPlacedProc(ABaseTower tower)
	{
	}
}
