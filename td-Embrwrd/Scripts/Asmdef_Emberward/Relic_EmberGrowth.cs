public class Relic_EmberGrowth : RelicTemplate_PlayerVictoryBased
{
	private int hpIncreaseValue;

	private int damageTakenInGame;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	protected override void OnPlayerVictoryProc()
	{
	}
}
