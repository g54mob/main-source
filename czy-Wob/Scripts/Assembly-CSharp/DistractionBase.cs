using UnityEngine;

public class DistractionBase
{
	protected DogBehaviorBase currentRunningBehavior;

	protected DistractionPriority priority;

	protected float weight = 1f;

	protected DogAI aiRef;

	public DistractionBase(DogAI newAIRef, float newWeight)
	{
		aiRef = newAIRef;
		weight = newWeight;
	}

	public virtual void Update()
	{
	}

	public DistractionPriority GetPriority()
	{
		return priority;
	}

	public bool CanBeReplaced(DistractionBase newDistraction, bool ignorePriority = false)
	{
		if (ignorePriority)
		{
			return true;
		}
		return newDistraction.GetPriority() > priority;
	}

	public float GetWeight()
	{
		return weight;
	}

	public bool IsRunningBehavior()
	{
		if (currentRunningBehavior != null && currentRunningBehavior.IsRunningBehavior())
		{
			return true;
		}
		return false;
	}

	public virtual bool FindNewBehavior(bool forceInterrupt)
	{
		Debug.LogError("FindNewBehavior() expects override!");
		return false;
	}

	public virtual void PreDestroy()
	{
	}
}
