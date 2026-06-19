using System.Collections.Generic;
using UnityEngine;

public class DistractionWitnessDeath : DistractionBase
{
	private bool hasHowled;

	private DoggyBrain dyingDogBrain;

	private bool partsAssigned;

	private List<GameObject> partsToEat = new List<GameObject>();

	private float afterHowlTimer = 5f;

	private DogBehaviorBase howlBehavior;

	public DistractionWitnessDeath(DogAI newAIRef, float newWeight, DoggyBrain dogBrain)
		: base(newAIRef, newWeight)
	{
		priority = DistractionPriority.WITNESS_DEATH;
		howlBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.HOWL][0];
		dyingDogBrain = dogBrain;
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
			FindNewBehavior(forceInterrupt: true);
		}
	}

	public override bool FindNewBehavior(bool forceInterrupt)
	{
		if (currentRunningBehavior != null)
		{
			return true;
		}
		if (!hasHowled || !partsAssigned)
		{
			if (hasHowled)
			{
				afterHowlTimer -= Time.fixedDeltaTime;
				if (afterHowlTimer <= 0f)
				{
					aiRef.OnDistractionDone(this);
					return false;
				}
			}
			else if (aiRef.TryRunBehavior(howlBehavior, null, forceInterrupt))
			{
				hasHowled = true;
				currentRunningBehavior = aiRef.GetCurrentBehavior();
				dyingDogBrain.RegisterWitness(aiRef.GetComponent<ObjectID>().GetUID());
				return true;
			}
			return true;
		}
		if (partsToEat.Count > 0)
		{
			ConsumeDogParts();
			return true;
		}
		aiRef.OnDistractionDone(this);
		return false;
	}

	public void RegisterPartsToEat(List<GameObject> edibles)
	{
		partsToEat.Clear();
		partsToEat.AddRange(edibles);
		partsAssigned = true;
	}

	private void ConsumeDogParts()
	{
		for (int num = partsToEat.Count - 1; num >= 0; num--)
		{
			if (partsToEat[num] == null)
			{
				partsToEat.RemoveAt(num);
			}
		}
		if (partsToEat.Count == 0)
		{
			aiRef.OnDistractionDone(this);
			return;
		}
		GameObject neededTarget = partsToEat[Random.Range(0, partsToEat.Count)];
		if (!aiRef.FindNewNeedBehavior(Need.Hunger, forceInterrupt: true, neededTarget))
		{
			aiRef.OnDistractionDone(this);
		}
		else
		{
			currentRunningBehavior = aiRef.GetCurrentBehavior();
		}
	}
}
