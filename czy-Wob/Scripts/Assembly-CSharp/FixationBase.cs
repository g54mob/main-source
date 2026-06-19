using UnityEngine;

public class FixationBase
{
	protected static float baseScore = 0.025f;

	protected static float playerHeldObjectBonusMultiplier = 2f;

	protected float lockoutTime = 10f;

	protected DogBehaviorBase currentRunningBehavior;

	protected float currentFixationTime;

	protected float maxFixationTime = 60f;

	protected DogAI aiRef;

	public FixationBase(DogAI newAIRef)
	{
		aiRef = newAIRef;
	}

	public float GetLockoutTime()
	{
		return lockoutTime;
	}

	public virtual void Update()
	{
		currentFixationTime += Time.deltaTime;
	}

	public bool IsRunningBehavior()
	{
		if (currentRunningBehavior != null && currentRunningBehavior.IsRunningBehavior())
		{
			return true;
		}
		return false;
	}

	protected virtual bool FindNewBehavior(bool forceInterrupt)
	{
		Debug.LogError("FindNewBehavior() expects override!");
		return false;
	}
}
