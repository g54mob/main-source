using System.Collections.Generic;
using UnityEngine;

public class DistractionLayEggs : DistractionBase
{
	private List<DogBehaviorBase> eggsBehaviors = new List<DogBehaviorBase>();

	private DogBehaviorBase capsuleBehavior;

	private bool layCapsuleInstead;

	private float timeAllowed = 30f;

	private float timePassed;

	private bool setToImmediate;

	private DoggyBrain brainRef;

	private LegController legRef;

	public DistractionLayEggs(DogAI newAIRef, float newWeight, bool layCapsule = false)
		: base(newAIRef, newWeight)
	{
		priority = DistractionPriority.HIGH;
		layCapsuleInstead = layCapsule;
		eggsBehaviors.AddRange(aiRef.fixationTypeBehaviorMapping[FixationType.LAY_EGGS]);
		capsuleBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.LAY_CAPSULE][0];
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
			return;
		}
		timePassed += Time.deltaTime;
		if (!setToImmediate && legRef.IsWalking() && (timePassed >= timeAllowed || brainRef.IsHungry() || brainRef.IsTired()))
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
		if (layCapsuleInstead)
		{
			if (aiRef.TryRunBehavior(capsuleBehavior, null, forceInterrupt))
			{
				currentRunningBehavior = aiRef.GetCurrentBehavior();
				return true;
			}
		}
		else
		{
			for (int i = 0; i < eggsBehaviors.Count; i++)
			{
				if (aiRef.TryRunBehavior(eggsBehaviors[i], null, forceInterrupt))
				{
					currentRunningBehavior = aiRef.GetCurrentBehavior();
					return true;
				}
			}
		}
		aiRef.OnDistractionDone(this);
		return false;
	}
}
