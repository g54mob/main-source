public class DamageCalculator : Singleton<DamageCalculator>
{
	public static int CalculateDamage(int damage, float baseCrit, eDamageType element, AMonsterBase monster)
	{
		return 0;
	}

	private int calculateDamage(int damage, float baseCrit, eDamageType element, AMonsterBase monster)
	{
		return 0;
	}

	public static float CalculateShootInterval(float baseInterval, eDamageType element)
	{
		return 0f;
	}

	private float calculateShootInterval(float baseInterval, eDamageType element)
	{
		return 0f;
	}

	public static float CalculateSlowEffectMultiplier(eDamageType element)
	{
		return 0f;
	}

	private float calculateSlowEffectMultiplier(eDamageType element)
	{
		return 0f;
	}

	private bool HasTalent(eTalentType talent)
	{
		return false;
	}

	private bool HasRelic(eItemType relic)
	{
		return false;
	}
}
