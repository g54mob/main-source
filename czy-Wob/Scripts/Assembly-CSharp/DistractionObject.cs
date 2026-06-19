using UnityEngine;

public class DistractionObject : DistractionBase
{
	protected GameObject distractionTarget;

	public DistractionObject(DogAI newAIRef, float newWeight, GameObject obj)
		: base(newAIRef, newWeight)
	{
		distractionTarget = obj;
		DoggyBrain component = newAIRef.GetComponent<DoggyBrain>();
		weight += weight * component.GetReinforcementMultiplierForTarget(obj);
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
		bool num = aiRef.FindNewTargetedBehavior(distractionTarget, forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
