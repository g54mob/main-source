public class Quest_DealArcaneDamage : AQuestBase
{
	private int damageDealt;

	private int requirement;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected override void OnSetupProc()
	{
	}

	private void OnMonsterHit(AMonsterBase monster, int damage, eDamageType type, bool isCrit, ABaseTower tower)
	{
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
