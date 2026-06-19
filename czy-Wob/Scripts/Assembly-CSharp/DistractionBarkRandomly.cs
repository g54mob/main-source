public class DistractionBarkRandomly : DistractionBase
{
	private DogBehaviorBase barkBehavior;

	public DistractionBarkRandomly(DogAI newAIRef, float newWeight, bool rapid = false)
		: base(newAIRef, newWeight)
	{
		if (rapid)
		{
			barkBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.BARK_RAPIDLY][0];
		}
		else
		{
			barkBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.BARK_RANDOMLY][0];
		}
		float reinforcementMultiplierForBehavior = newAIRef.GetComponent<DoggyBrain>().GetReinforcementMultiplierForBehavior(barkBehavior);
		weight += weight * reinforcementMultiplierForBehavior;
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
		bool num = aiRef.TryRunBehavior(barkBehavior, null, forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
