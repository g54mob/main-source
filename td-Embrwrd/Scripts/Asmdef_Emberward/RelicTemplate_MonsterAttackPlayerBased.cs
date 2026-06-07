public abstract class RelicTemplate_MonsterAttackPlayerBased : ARelicBase
{
	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	protected virtual void OnMonsterDealDamageToPlayerProc(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}
}
