using System.Collections.Generic;

public class Relic_CursedTarot : ARelicBase
{
	private List<AMonsterBase> list_EffectedMonsters;

	private int effectStackCount;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnHandCardChanged(List<CardData> list)
	{
	}
}
