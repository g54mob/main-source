public class DistractionBarf : DistractionBase
{
	private DogBehaviorBase barfBehavior;

	public DistractionBarf(DogAI newAIRef, float newWeight)
		: base(newAIRef, newWeight)
	{
		priority = DistractionPriority.HIGH;
		barfBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.BARF][0];
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
		bool num = aiRef.TryRunBehavior(barfBehavior, null, forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
