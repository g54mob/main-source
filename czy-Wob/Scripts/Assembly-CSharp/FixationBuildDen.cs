using System.Collections.Generic;
using UnityEngine;

public class FixationBuildDen : FixationBase
{
	private DogBehaviorBase clearAreaBehavior;

	private DogBehaviorBase digHoleBehavior;

	private DogBehaviorBase collectDirtClumpBehavior;

	private DogBehaviorBase collectSnowballBehavior;

	private DogBehaviorBase finalizeDenBehavior;

	private ulong dogID;

	private static float denLockoutTime = 60f;

	private static float fixationScoreMultiplier = 100f;

	private float denCheckTimer = 3f;

	private float currentDenCheckTimer;

	protected RoomBase associatedRoom;

	protected ulong? associatedRoomUID;

	private ObjectRegistration regRef;

	public FixationBuildDen(DogAI newAIRef)
		: base(newAIRef)
	{
		lockoutTime = denLockoutTime;
		digHoleBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.DIG_HOLE][0];
		clearAreaBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.BUILD_DEN][0];
		collectDirtClumpBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.GATHER_DIRT][0];
		collectSnowballBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.GATHER_SNOW][0];
		finalizeDenBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.FINALIZE_DEN][0];
		regRef = ObjectRegistration.GetRegistrationScript();
		dogID = regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetIDFromDog(aiRef.gameObject);
		BoundingBoxComponent component = aiRef.GetComponent<BoundingBoxComponent>();
		associatedRoomUID = component.GetRoomUID();
		associatedRoom = component.GetCurrentRoom();
		maxFixationTime *= 2f;
	}

	public static void ScoreAndAddFixations(GameObject dog, ref List<ScorableFixation> fixationList, ref List<float> fixationScores)
	{
		if (!TutorialController.IsTutorialActive() && DenInteriorManager.CanBuildNewDenInteriors() && dog.GetComponent<DoggyBrain>().GetCurrentDogAge() >= DogAge.TEEN)
		{
			RoomBase currentRoom = dog.GetComponent<BoundingBoxComponent>().GetCurrentRoom();
			if (!(currentRoom == null) && currentRoom.GetNumberOfDens(requireComplete: true) < currentRoom.GetNumberOfDensToBuild())
			{
				ScorableFixation item = new ScorableFixation
				{
					fixationType = FixationType.BUILD_DEN
				};
				float num = FixationBase.baseScore * fixationScoreMultiplier;
				num *= 1000f;
				fixationList.Add(item);
				fixationScores.Add(num);
			}
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
		if (associatedRoom == null)
		{
			aiRef.OnFixationDone();
			return false;
		}
		if (currentRunningBehavior != null)
		{
			currentDenCheckTimer += Time.deltaTime;
			if (currentDenCheckTimer >= denCheckTimer)
			{
				currentDenCheckTimer = 0f;
				if (associatedRoom.GetNumberOfDens(requireComplete: true) >= associatedRoom.GetNumberOfDensToBuild())
				{
					aiRef.OnFixationDone();
					return false;
				}
			}
			return true;
		}
		if (associatedRoom.GetNumberOfDens(requireComplete: true) >= associatedRoom.GetNumberOfDensToBuild())
		{
			aiRef.OnFixationDone();
			return false;
		}
		if (DogDenManager.IsAreaBeingClearedInRoom(associatedRoomUID))
		{
			aiRef.FindNewBehavior();
			currentRunningBehavior = aiRef.GetCurrentBehavior();
			return true;
		}
		List<DogDen> objects = DogDenManager.GetAllAccessibleIncompleteDensInRoom(dogID, associatedRoomUID);
		if (objects.Count == 0)
		{
			if (aiRef.TryRunBehavior(clearAreaBehavior, null, forceInterrupt))
			{
				currentRunningBehavior = aiRef.GetCurrentBehavior();
				return true;
			}
		}
		else
		{
			DoggyBrain component = aiRef.GetComponent<DoggyBrain>();
			MischiefPersonalityType mischiefPersonality = component.GetPersonality().GetMischiefPersonality();
			NicenessPersonalityType nicenessPersonalityType = component.GetPersonality().GetNicenessPersonalityType();
			ListUtil.ShuffleList(ref objects);
			bool flag = false;
			if (mischiefPersonality == MischiefPersonalityType.MISCHEVIOUS || nicenessPersonalityType == NicenessPersonalityType.MEAN)
			{
				flag = true;
			}
			DogDen dogDen = null;
			for (int i = 0; i < objects.Count; i++)
			{
				if (objects[i].CanFinalize())
				{
					dogDen = objects[i];
					break;
				}
			}
			bool isSnowy = objects[objects.Count - 1].GetIsSnowy();
			bool flag2 = false;
			DogBehaviorBase behavior;
			bool flag3;
			if (isSnowy)
			{
				behavior = collectSnowballBehavior;
				flag3 = regRef.DoObjectsExistForTag(TagsEnum.SNOWBALL);
				if (flag3 && (flag || regRef.DoFreeObjectsExistForTag(TagsEnum.SNOWBALL, dogID)))
				{
					flag2 = true;
				}
			}
			else
			{
				behavior = collectDirtClumpBehavior;
				flag3 = regRef.DoObjectsExistForTag(TagsEnum.DIRT_CLUMP);
				if (flag3 && (flag || regRef.DoFreeObjectsExistForTag(TagsEnum.DIRT_CLUMP, dogID)))
				{
					flag2 = true;
				}
			}
			if (dogDen != null)
			{
				if (aiRef.TryRunBehavior(finalizeDenBehavior, dogDen.gameObject, forceInterrupt))
				{
					currentRunningBehavior = aiRef.GetCurrentBehavior();
					currentRunningBehavior.StorePosition(dogDen.transform.position);
					return true;
				}
			}
			else
			{
				if (flag3 && flag2 && aiRef.TryRunBehavior(behavior, null, forceInterrupt))
				{
					currentRunningBehavior = aiRef.GetCurrentBehavior();
					GameObject gameObject = objects[objects.Count - 1].gameObject;
					currentRunningBehavior.StorePosition(gameObject.transform.position);
					return true;
				}
				if (aiRef.TryRunBehavior(digHoleBehavior, null, forceInterrupt))
				{
					currentRunningBehavior = aiRef.GetCurrentBehavior();
					return true;
				}
			}
		}
		aiRef.OnFixationDone();
		return false;
	}
}
