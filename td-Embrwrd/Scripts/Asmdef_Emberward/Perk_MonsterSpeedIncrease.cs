using System.Collections.Generic;

public class Perk_MonsterSpeedIncrease : APerkBase
{
	private List<ABaseTower> list_BuffedTowers;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnMonsterSpawn(AMonsterBase monster)
	{
	}
}
