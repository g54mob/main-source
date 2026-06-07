public abstract class RelicTemplate_MonsterHitBased : ARelicBase
{
	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnMonsterHit(AMonsterBase monster, int value, eDamageType damageType, bool isCrit, ABaseTower tower)
	{
	}

	protected virtual void OnMonsterHitProc(AMonsterBase monster, int value, eDamageType damageType, bool isCrit, ABaseTower tower)
	{
	}
}
