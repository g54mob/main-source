using UnityEngine;

public class DistractionGrowl : DistractionBase
{
	private GameObject targetObject;

	private DogBehaviorBase growlBehavior;

	public DistractionGrowl(DogAI newAIRef, float newWeight, GameObject target)
		: base(newAIRef, newWeight)
	{
		targetObject = target;
		growlBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.GROWL][0];
		float reinforcementMultiplierForBehaviorTargetCombo = newAIRef.GetComponent<DoggyBrain>().GetReinforcementMultiplierForBehaviorTargetCombo(growlBehavior, target);
		weight += weight * reinforcementMultiplierForBehaviorTargetCombo;
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
		bool num = aiRef.TryRunBehavior(growlBehavior, targetObject, forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
