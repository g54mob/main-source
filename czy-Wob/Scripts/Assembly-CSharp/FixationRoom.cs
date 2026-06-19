using System.Collections.Generic;
using UnityEngine;

public class FixationRoom : FixationBase
{
	private bool hasRunBehavior;

	private List<DogBehaviorBase> roomBehaviors = new List<DogBehaviorBase>();

	public FixationRoom(DogAI newAIRef)
		: base(newAIRef)
	{
		lockoutTime = 60f;
		roomBehaviors.AddRange(aiRef.fixationTypeBehaviorMapping[FixationType.ROOM]);
	}

	public static void ScoreAndAddFixations(GameObject dog, ref List<ScorableFixation> fixationList, ref List<float> fixationScores)
	{
		ConstructionManager globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER, nullAllowed: true);
		if (!(globalComponent == null) && dog.GetComponent<BoundingBoxComponent>().GetRoomUID().HasValue && globalComponent.GetAllRooms().Count > 1)
		{
			ScorableFixation item = new ScorableFixation
			{
				fixationType = FixationType.ROOM
			};
			float item2 = FixationBase.baseScore;
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
		if (currentRunningBehavior == null && (currentFixationTime >= maxFixationTime || hasRunBehavior))
		{
			aiRef.OnFixationDone();
			return;
		}
		FindNewBehavior(currentRunningBehavior == null);
		if (currentRunningBehavior != null)
		{
			hasRunBehavior = true;
		}
	}

	protected override bool FindNewBehavior(bool forceInterrupt)
	{
		if (currentRunningBehavior != null)
		{
			return true;
		}
		for (int i = 0; i < roomBehaviors.Count; i++)
		{
			if (aiRef.TryRunBehavior(roomBehaviors[i], null, forceInterrupt))
			{
				currentRunningBehavior = aiRef.GetCurrentBehavior();
				return true;
			}
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		aiRef.OnFixationDone();
		return false;
	}
}
