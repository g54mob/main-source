using UnityEngine;

public class DistractionComplain : DistractionBase
{
	private GameObject targetObject;

	private DogBehaviorBase complainBehavior;

	public DistractionComplain(DogAI newAIRef, float newWeight, GameObject target)
		: base(newAIRef, newWeight)
	{
		targetObject = target;
		complainBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.COMPLAIN][0];
		float reinforcementMultiplierForBehaviorTargetCombo = newAIRef.GetComponent<DoggyBrain>().GetReinforcementMultiplierForBehaviorTargetCombo(complainBehavior, target);
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
		bool num = aiRef.TryRunBehavior(complainBehavior, targetObject, forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
