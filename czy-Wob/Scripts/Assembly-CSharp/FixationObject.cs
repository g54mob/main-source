using System.Collections.Generic;
using UnityEngine;

public class FixationObject : FixationBase
{
	private GameObject currentFixationObject;

	public FixationObject(DogAI newAIRef, GameObject chosenTarget)
		: base(newAIRef)
	{
		currentFixationObject = chosenTarget;
	}

	public static void ScoreAndAddFixations(GameObject dog, ref List<ScorableFixation> fixationList, ref List<float> fixationScores)
	{
		ulong? roomUID = dog.GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!roomUID.HasValue)
		{
			return;
		}
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		ObjectGrabber globalComponent = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER, nullAllowed: true);
		GameObject objectForUID = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER).GetObjectForUID(roomUID.Value);
		if (objectForUID == null)
		{
			return;
		}
		BoundingBoxComponent component = objectForUID.GetComponent<BoundingBoxComponent>();
		List<GameObject> allObjectsForTag = registrationScript.GetAllObjectsForTag(TagsEnum.ALL);
		int num = 0;
		for (int num2 = allObjectsForTag.Count - 1; num2 >= 0; num2--)
		{
			if (allObjectsForTag[num2] != null && allObjectsForTag[num2].tag != Tags.DOG)
			{
				BoundingBoxComponent component2 = allObjectsForTag[num2].GetComponent<BoundingBoxComponent>();
				if (component2 != null && component.DoesThisBoxContainOther(component2.GetBoxCenter(), component2.GetBoxSize()))
				{
					num++;
					continue;
				}
			}
			allObjectsForTag.RemoveAt(num2);
		}
		GameObject gameObject = null;
		if (globalComponent != null)
		{
			gameObject = globalComponent.GetGrabbedObject();
		}
		DoggyBrain component3 = dog.GetComponent<DoggyBrain>();
		for (int i = 0; i < allObjectsForTag.Count; i++)
		{
			ScorableFixation item = new ScorableFixation
			{
				fixationType = FixationType.OBJECT,
				target = allObjectsForTag[i]
			};
			float num3 = FixationBase.baseScore / (float)num;
			if (gameObject == allObjectsForTag[i])
			{
				num3 *= FixationBase.playerHeldObjectBonusMultiplier;
			}
			num3 += num3 * component3.GetReinforcementMultiplierForTarget(allObjectsForTag[i], FeelingTowardsTarget.POSITIVE);
			fixationList.Add(item);
			fixationScores.Add(num3);
		}
	}

	public override void Update()
	{
		base.Update();
		if (currentRunningBehavior != null && !currentRunningBehavior.IsRunningBehavior())
		{
			currentRunningBehavior = null;
		}
		if (currentRunningBehavior == null && (currentFixationTime >= maxFixationTime || currentFixationObject == null))
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
		bool num = aiRef.FindNewFixationTypeBehavior(FixationType.OBJECT, forceInterrupt, currentFixationObject);
		if (!num)
		{
			aiRef.OnFixationDone();
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
