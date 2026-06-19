using System.Collections.Generic;

public class DistractionPoop : DistractionBase
{
	private List<DogBehaviorBase> poopBehaviors = new List<DogBehaviorBase>();

	private bool setToImmediate;

	private DoggyBrain brainRef;

	private LegController legRef;

	public DistractionPoop(DogAI newAIRef, float newWeight)
		: base(newAIRef, newWeight)
	{
		priority = DistractionPriority.HIGH;
		poopBehaviors.AddRange(aiRef.fixationTypeBehaviorMapping[FixationType.POOP]);
		brainRef = newAIRef.GetComponent<DoggyBrain>();
		legRef = newAIRef.GetComponent<LegController>();
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
		else if (!currentRunningBehavior.InternalStartConditionsMet())
		{
			aiRef.ForceInterruptBehavior();
			FindNewBehavior(forceInterrupt: true);
		}
		else if (!setToImmediate && legRef.IsWalking() && (brainRef.IsHungry() || brainRef.IsTired()))
		{
			setToImmediate = true;
			aiRef.GetComponent<WalkController>().FinishPathPrematurely();
		}
	}

	public override bool FindNewBehavior(bool forceInterrupt)
	{
		if (currentRunningBehavior != null)
		{
			return true;
		}
		for (int i = 0; i < poopBehaviors.Count; i++)
		{
			if (aiRef.TryRunBehavior(poopBehaviors[i], null, forceInterrupt))
			{
				currentRunningBehavior = aiRef.GetCurrentBehavior();
				return true;
			}
		}
		aiRef.OnDistractionDone(this);
		return false;
	}
}
