using System;

[Serializable]
public class GrowingSettings
{
	public int highestStage;

	public float timeBetweenStages;

	public int currentStage;

	public bool keepDamageReductionWhenRipe;
}
