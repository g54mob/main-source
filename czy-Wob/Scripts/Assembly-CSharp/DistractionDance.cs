using System.Collections.Generic;

public class DistractionDance : DistractionBase
{
	private DogBehaviorBase danceBehavior;

	public DistractionDance(DogAI newAIRef, float newWeight, bool shouldSway)
		: base(newAIRef, newWeight)
	{
		List<DogBehaviorBase> list = aiRef.fixationTypeBehaviorMapping[FixationType.HAPPINESS];
		for (int i = 0; i < list.Count; i++)
		{
			if (!shouldSway && list[i].readableName == "Bouncing")
			{
				danceBehavior = list[i];
				break;
			}
			if (shouldSway && list[i].readableName == "Swaying")
			{
				danceBehavior = list[i];
				break;
			}
		}
		float reinforcementMultiplierForBehavior = newAIRef.GetComponent<DoggyBrain>().GetReinforcementMultiplierForBehavior(danceBehavior);
		weight += weight * reinforcementMultiplierForBehavior;
	}

	public override void Update()
	{
		base.Update();
		if (currentRunningBehavior != null && !currentRunningBehavior.IsRunningBehavior())
		{
			currentRunningBehavior = null;
		}
		if (currentRunningBehavior == null)
		{
			aiRef.OnDistractionDone(this);
		}
	}

	public override bool FindNewBehavior(bool forceInterrupt)
	{
		if (currentRunningBehavior != null)
		{
			return true;
		}
		bool num = aiRef.TryRunBehavior(danceBehavior, null, forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
