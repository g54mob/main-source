public class DistractionNeed : DistractionBase
{
	protected Need needToSatisfy;

	private DoggyBrain brainRef;

	public DistractionNeed(DogAI newAIRef, float newWeight, Need need)
		: base(newAIRef, newWeight)
	{
		needToSatisfy = need;
		if (need == Need.Hunger || need == Need.Energy)
		{
			priority = DistractionPriority.HIGH;
		}
		else
		{
			priority = DistractionPriority.MEDIUM;
		}
		brainRef = newAIRef.GetComponent<DoggyBrain>();
	}

	public override string ToString()
	{
		return base.ToString() + " : " + needToSatisfy;
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
			if (brainRef.GetCurrentNeed() == needToSatisfy)
			{
				FindNewBehavior(forceInterrupt: true);
			}
			else
			{
				aiRef.OnDistractionDone(this);
			}
		}
		else if (needToSatisfy == Need.Energy && !brainRef.IsSleeping() && !currentRunningBehavior.InternalStartConditionsMet())
		{
			aiRef.ForceInterruptBehavior();
			FindNewBehavior(forceInterrupt: true);
		}
	}

	public override bool FindNewBehavior(bool forceInterrupt)
	{
		if (currentRunningBehavior != null)
		{
			return true;
		}
		bool num = aiRef.FindNewNeedBehavior(needToSatisfy, forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
