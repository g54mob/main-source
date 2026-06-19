public class DistractionMoveAwayFromDogs : DistractionBase
{
	protected DogBehaviorBase walkToLocationBehavior;

	public DistractionMoveAwayFromDogs(DogAI newAIRef, float newWeight)
		: base(newAIRef, newWeight)
	{
		priority = DistractionPriority.MEDIUM;
		walkToLocationBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.GET_AWAY_FROM_DOGS][0];
		DoggyBrain component = newAIRef.GetComponent<DoggyBrain>();
		weight += weight * component.GetReinforcementMultiplierForProperty(TagsEnum.DOG.ToString(), FeelingTowardsTarget.NEGATIVE);
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
		currentRunningBehavior = walkToLocationBehavior;
		bool num = aiRef.TryRunBehavior(currentRunningBehavior, null, forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		return num;
	}
}
