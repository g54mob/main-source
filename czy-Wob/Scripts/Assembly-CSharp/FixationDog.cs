using System.Collections.Generic;
using UnityEngine;

public class FixationDog : FixationBase
{
	private GameObject currentFixationObject;

	private static float socialPersonalityModifier = 2f;

	private static float aloofPersonalityModifier = 0.1f;

	public FixationDog(DogAI newAIRef, GameObject chosenTarget)
		: base(newAIRef)
	{
		lockoutTime = 0f;
		currentFixationObject = chosenTarget;
	}

	public static void ScoreAndAddFixations(GameObject dog, ref List<ScorableFixation> fixationList, ref List<float> fixationScores)
	{
		ObjectGrabber globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER, nullAllowed: true);
		DogRegistration globalComponent2 = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION, nullAllowed: true);
		if (globalComponent2 == null)
		{
			return;
		}
		DoggyBrain component = dog.GetComponent<DoggyBrain>();
		SocialPersonalityType socialPersonality = component.GetPersonality().GetSocialPersonality();
		List<GameObject> nearbyDogList = new List<GameObject>();
		globalComponent2.GetNearbyDogList(dog, ref nearbyDogList);
		for (int i = 0; i < nearbyDogList.Count; i++)
		{
			ScorableFixation item = new ScorableFixation
			{
				fixationType = FixationType.DOG,
				target = nearbyDogList[i]
			};
			float num = FixationBase.baseScore;
			if (globalComponent != null && globalComponent.GetGrabbedObject() == nearbyDogList[i])
			{
				num *= FixationBase.playerHeldObjectBonusMultiplier;
			}
			switch (socialPersonality)
			{
			case SocialPersonalityType.ALOOF:
				num *= aloofPersonalityModifier;
				break;
			case SocialPersonalityType.SOCIAL:
				num *= socialPersonalityModifier;
				break;
			}
			num += num * component.GetReinforcementMultiplierForTarget(nearbyDogList[i], FeelingTowardsTarget.POSITIVE);
			fixationList.Add(item);
			fixationScores.Add(num);
		}
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
			if (currentFixationTime >= maxFixationTime || currentFixationObject == null)
			{
				aiRef.OnFixationDone();
				return;
			}
			if (!CanSeeDog())
			{
				aiRef.OnFixationDone();
				return;
			}
		}
		FindNewBehavior(currentRunningBehavior == null);
	}

	private bool CanSeeDog()
	{
		Vector3 position = aiRef.GetComponent<LegController>().internalFacingObj.transform.position;
		Vector3 position2 = currentFixationObject.GetComponent<LegController>().internalFacingObj.transform.position;
		float dist = Vector3.Distance(position, position2);
		if (!RaycastUtil.StageRaycast(position, position2 - position, dist))
		{
			return true;
		}
		return false;
	}

	protected override bool FindNewBehavior(bool forceInterrupt)
	{
		if (currentRunningBehavior != null)
		{
			return true;
		}
		bool num = aiRef.FindNewTargetedBehavior(currentFixationObject, forceInterrupt);
		if (!num)
		{
			aiRef.OnFixationDone();
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
