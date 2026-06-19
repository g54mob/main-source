using UnityEngine;

public class DistractionFood : DistractionBase
{
	protected GameObject distractionTarget;

	public DistractionFood(DogAI newAIRef, float newWeight, GameObject obj)
		: base(newAIRef, newWeight)
	{
		distractionTarget = obj;
		float reinforcementMultiplierForTarget = newAIRef.GetComponent<DoggyBrain>().GetReinforcementMultiplierForTarget(obj);
		weight += weight * reinforcementMultiplierForTarget;
	}

	public override void Update()
	{
		base.Update();
		if (currentRunningBehavior != null && !currentRunningBehavior.IsRunningBehavior())
		{
			currentRunningBehavior = null;
		}
		if (currentRunningBehavior == null || distractionTarget == null)
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
		bool num = aiRef.FindNewNeedBehavior(Need.Hunger, forceInterrupt, distractionTarget);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
