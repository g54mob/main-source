using System.Collections.Generic;
using UnityEngine;

public class FixationExpandDen : FixationBase
{
	private DogBehaviorBase expandDenBehavior;

	private DogBehaviorBase clearDenBehavior;

	private ulong dogID;

	private static float fixationScoreMultiplier = 10f;

	private bool hasRunBehavior;

	private ObjectRegistration regRef;

	public FixationExpandDen(DogAI newAIRef)
		: base(newAIRef)
	{
		expandDenBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.EXPAND_DEN][0];
		clearDenBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.REMOVE_DIRT_FROM_DEN][0];
		regRef = ObjectRegistration.GetRegistrationScript();
		dogID = regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetIDFromDog(aiRef.gameObject);
		maxFixationTime *= 2f;
	}

	public static void ScoreAndAddFixations(GameObject dog, ref List<ScorableFixation> fixationList, ref List<float> fixationScores)
	{
		if (dog.GetComponent<DoggyBrain>().GetCurrentDogAge() >= DogAge.TEEN && DogDenManager.CanDogAccessAndExpandAnyCompletedDen(dog.GetComponent<ObjectID>().GetUID()).HasValue)
		{
			ScorableFixation item = new ScorableFixation
			{
				fixationType = FixationType.EXPAND_DEN
			};
			float item2 = FixationBase.baseScore * fixationScoreMultiplier;
			fixationList.Add(item);
			fixationScores.Add(item2);
		}
	}

	public override void Update()
	{
		base.Update();
		if (currentRunningBehavior != null && !currentRunningBehavior.IsRunningBehavior())
		{
			currentRunningBehavior = null;
		}
		if (currentRunningBehavior == null && currentFixationTime >= maxFixationTime)
		{
			aiRef.OnFixationDone();
		}
		else
		{
			FindNewBehavior(currentRunningBehavior == null);
		}
	}

	protected override bool FindNewBehavior(bool forceInterrupt)
	{
		if (currentRunningBehavior != null)
		{
			return true;
		}
		if (hasRunBehavior)
		{
			aiRef.OnFixationDone();
			return false;
		}
		ulong? num = DogDenManager.CanDogAccessAndExpandAnyCompletedDen(dogID);
		if (!num.HasValue)
		{
			aiRef.OnFixationDone();
			return false;
		}
		DenExpansion freeDenExpansion = DenInteriorManager.GetInteriorForDenID(num.Value).GetComponent<DogDenInterior>().GetFreeDenExpansion();
		if (DenInteriorManager.GetAllContainedObjects(num.Value, TagsEnum.DIRT_CLUMP).Count + DenInteriorManager.GetAllContainedObjects(num.Value, TagsEnum.SNOWBALL).Count > 0)
		{
			if (aiRef.TryRunBehavior(clearDenBehavior, null, forceInterrupt))
			{
				currentRunningBehavior = aiRef.GetCurrentBehavior();
				return true;
			}
		}
		else if (aiRef.TryRunBehavior(expandDenBehavior, null, forceInterrupt, userIssued: false, freeDenExpansion.GetCurrentExpansionTransform().position))
		{
			currentRunningBehavior = aiRef.GetCurrentBehavior();
			currentRunningBehavior.StoreDenExpansion(freeDenExpansion);
			currentRunningBehavior.StorePosition(freeDenExpansion.GetCurrentExpansionTransform().position);
			freeDenExpansion.RegisterDog(dogID);
			hasRunBehavior = true;
			return true;
		}
		aiRef.OnFixationDone();
		return false;
	}
}
