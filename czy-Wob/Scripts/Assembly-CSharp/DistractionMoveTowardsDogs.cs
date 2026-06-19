public class DistractionMoveTowardsDogs : DistractionBase
{
	protected DogBehaviorBase walkToLocationBehavior;

	public DistractionMoveTowardsDogs(DogAI newAIRef, float newWeight)
		: base(newAIRef, newWeight)
	{
		priority = DistractionPriority.MEDIUM;
		walkToLocationBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.GET_CLOSER_TO_DOGS][0];
		DoggyBrain component = newAIRef.GetComponent<DoggyBrain>();
		weight += weight * component.GetReinforcementMultiplierForProperty(TagsEnum.DOG.ToString(), FeelingTowardsTarget.POSITIVE);
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
