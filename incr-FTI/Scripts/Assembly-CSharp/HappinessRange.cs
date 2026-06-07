public class HappinessRange
{
	public int minHappinessInclusive;

	public int maxHappinessExclusive;

	public float productionBonus;

	public HappinessRange(int min, float bonus)
	{
		minHappinessInclusive = min;
		maxHappinessExclusive = int.MaxValue;
		productionBonus = bonus;
	}

	public bool IsInRange(int testValue)
	{
		if (testValue >= minHappinessInclusive)
		{
			return testValue < maxHappinessExclusive;
		}
		return false;
	}
}
