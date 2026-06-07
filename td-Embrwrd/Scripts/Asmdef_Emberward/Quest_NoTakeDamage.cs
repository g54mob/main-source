public class Quest_NoTakeDamage : AQuestBase
{
	private bool isTakenDamage;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
