public class DistractionBark : DistractionBase
{
	private DogBehaviorBase barkBehavior;

	public DistractionBark(DogAI newAIRef, float newWeight)
		: base(newAIRef, newWeight)
	{
		barkBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.BARK][0];
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
