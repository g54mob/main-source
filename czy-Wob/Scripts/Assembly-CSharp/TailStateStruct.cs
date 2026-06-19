public struct TailStateStruct
{
	public float minAnger;

	public float maxAnger;

	public float minEnergy;

	public float maxEnergy;

	public float minHunger;

	public float maxHunger;

	public float minStress;

	public float maxStress;

	public float minBoredom;

	public float maxBoredom;

	public bool requireAll;

	public bool StateValid(DoggyBrain brain)
	{
		float percentageValueForNeed = brain.GetPercentageValueForNeed(Need.Anger);
		float percentageValueForNeed2 = brain.GetPercentageValueForNeed(Need.Energy);
		float percentageValueForNeed3 = brain.GetPercentageValueForNeed(Need.Hunger);
		float percentageValueForNeed4 = brain.GetPercentageValueForNeed(Need.Stress);
		float percentageValueForNeed5 = brain.GetPercentageValueForNeed(Need.Boredom);
		if (requireAll)
		{
			if (percentageValueForNeed >= minAnger && percentageValueForNeed <= maxAnger && percentageValueForNeed4 >= minStress && percentageValueForNeed4 <= maxStress && percentageValueForNeed2 >= minEnergy && percentageValueForNeed2 <= maxEnergy && percentageValueForNeed3 >= minHunger && percentageValueForNeed3 <= maxHunger && percentageValueForNeed5 >= minBoredom && percentageValueForNeed5 <= maxBoredom)
			{
				return true;
			}
			return false;
		}
		if ((percentageValueForNeed >= minAnger && percentageValueForNeed <= maxAnger) || (percentageValueForNeed4 >= minStress && percentageValueForNeed4 <= maxStress) || (percentageValueForNeed2 >= minEnergy && percentageValueForNeed2 <= maxEnergy) || (percentageValueForNeed3 >= minHunger && percentageValueForNeed3 <= maxHunger) || (percentageValueForNeed5 >= minBoredom && percentageValueForNeed5 <= maxBoredom))
		{
			return true;
		}
		return false;
	}

	public float GetPercentValid(DoggyBrain brain, bool ignoreStress = false, bool ignoreHunger = false, bool ignoreEnergy = false, bool ignoreAnger = false, bool ignoreBoredom = false)
	{
		if (!StateValid(brain))
		{
			return 0f;
		}
		float percentageValueForNeed = brain.GetPercentageValueForNeed(Need.Anger);
		float percentageValueForNeed2 = brain.GetPercentageValueForNeed(Need.Energy);
		float percentageValueForNeed3 = brain.GetPercentageValueForNeed(Need.Hunger);
		float percentageValueForNeed4 = brain.GetPercentageValueForNeed(Need.Stress);
		float percentageValueForNeed5 = brain.GetPercentageValueForNeed(Need.Boredom);
		int num = 0;
		float num2 = 0f;
		if (!ignoreAnger)
		{
			num++;
			num2 += AddValidity(minAnger, maxAnger, percentageValueForNeed);
		}
		if (!ignoreStress)
		{
			num++;
			num2 += AddValidity(minStress, maxStress, percentageValueForNeed4);
		}
		if (!ignoreEnergy)
		{
			num++;
			num2 += AddValidity(minEnergy, maxEnergy, percentageValueForNeed2, reverseCalculation: true);
		}
		if (!ignoreHunger)
		{
			num++;
			num2 += AddValidity(minHunger, maxHunger, percentageValueForNeed3);
		}
		if (!ignoreBoredom)
		{
			num++;
			num2 += AddValidity(minBoredom, maxBoredom, percentageValueForNeed5);
		}
		return num2 / (float)num;
	}

	private float AddValidity(float min, float max, float current, bool reverseCalculation = false)
	{
		if (max - min == 0f)
		{
			return 1f;
		}
		if (reverseCalculation)
		{
			return 1f - (max - current) / (max - min);
		}
		return (max - current) / (max - min);
	}
}
