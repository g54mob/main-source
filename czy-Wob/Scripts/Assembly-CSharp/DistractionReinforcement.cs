using UnityEngine;

public class DistractionReinforcement : DistractionBase
{
	protected GameObject distractionTarget;

	protected DogBehaviorBase distractionBehavior;

	public DistractionReinforcement(DogAI newAIRef, float newWeight)
		: base(newAIRef, newWeight)
	{
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
		bool num = aiRef.FindNewReinforcedBehavior(forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
