public abstract class RelicTemplate_MonsterKillBased : ARelicBase
{
	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnMonsterKilled(AMonsterBase monster)
	{
	}

	protected virtual void OnMonsterKilledProc(AMonsterBase monster)
	{
	}
}
