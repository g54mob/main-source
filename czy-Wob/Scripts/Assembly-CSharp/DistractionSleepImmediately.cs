public class DistractionSleepImmediately : DistractionBase
{
	private DogBehaviorBase sleepBehavior;

	public DistractionSleepImmediately(DogAI newAIRef, float newWeight)
		: base(newAIRef, newWeight)
	{
		priority = DistractionPriority.HIGH;
		sleepBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.SLEEP_IMMEDIATELY][0];
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
		if (aiRef.TryRunBehavior(sleepBehavior, null, forceInterrupt))
		{
			currentRunningBehavior = aiRef.GetCurrentBehavior();
			return true;
		}
		aiRef.OnDistractionDone(this);
		return false;
	}
}
