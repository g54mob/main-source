using UnityEngine;

public class DistractionDogBehavior : DistractionBase
{
	protected GameObject distractionTarget;

	protected DogBehaviorBase distractionBehavior;

	public DistractionDogBehavior(DogAI newAIRef, float newWeight, DogBehaviorBase behavior, GameObject target)
		: base(newAIRef, newWeight)
	{
		distractionTarget = target;
		distractionBehavior = behavior;
		float reinforcementMultiplierForBehaviorTargetCombo = newAIRef.GetComponent<DoggyBrain>().GetReinforcementMultiplierForBehaviorTargetCombo(behavior, target);
		weight += weight * reinforcementMultiplierForBehaviorTargetCombo;
	}

	public override string ToString()
	{
		return string.Concat(base.ToString(), " : ", distractionTarget, " : ", distractionBehavior);
	}

	public override void Update()
	{
		base.Update();
		if (currentRunningBehavior != null && !currentRunningBehavior.IsRunningBehavior())
		{
			currentRunningBehavior = null;
		}
		if (currentRunningBehavior == null || (currentRunningBehavior.IsTargeted() && distractionTarget == null))
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
		bool num = aiRef.TryRunBehavior(distractionBehavior, distractionTarget, forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
