using System;
using UnityEngine;

[Serializable]
public class DogBehaviorRoom : DogBehaviorBase
{
	private DogBehaviorRoomEnum roomEnum;

	public override float GetNeedAdvertisement(Need need, GameObject potentialTarget)
	{
		if (!advertise)
		{
			return 0f;
		}
		return base.GetNeedAdvertisement(need);
	}

	public override DogBehaviorRoomEnum GetRoomEnum()
	{
		return roomEnum;
	}

	protected override void AssignEnum()
	{
		base.AssignEnum();
		roomEnum = (DogBehaviorRoomEnum)Enum.Parse(typeof(DogBehaviorRoomEnum), base.gameObject.name);
	}

	public override void FinishBehavior(bool naturalFinish = true, GameObject objectCause = null)
	{
		base.FinishBehavior(naturalFinish, objectCause);
		associatedAI.ClearTargetRoom();
	}

	protected override bool NeedsCancel()
	{
		if (associatedAI.GetTargetRoom() == null)
		{
			return true;
		}
		return false;
	}

	protected override void RunAction(DogAction action)
	{
		runningAction = true;
		switch (action)
		{
		case DogAction.WALK_TO_ROOM:
			TargetPointHelper.TargetRoom(associatedDog, GetTargetRoom(), base.ActionFinishedCallback);
			break;
		case DogAction.WALK_TO_RANDOM_ROOM:
			TargetPointHelper.TargetRoom(associatedDog, GetTargetRoom(), base.ActionFinishedCallback);
			break;
		case DogAction.LAY_EGGS:
			associatedDog.GetComponent<DogEggLayingController>().LayEggs(base.ActionFinishedCallback);
			break;
		case DogAction.SLEEP_IN_ROOM:
			associatedDog.GetComponent<SleepBehavior>().RequestSleep(base.ActionFinishedCallback);
			break;
		default:
			base.RunAction(action);
			break;
		}
	}

	protected override void FinalizeAction(DogAction action, bool naturalFinish)
	{
		switch (action)
		{
		case DogAction.WALK_TO_ROOM:
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			break;
		case DogAction.WALK_TO_RANDOM_ROOM:
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			break;
		case DogAction.SLEEP_IN_ROOM:
			associatedDog.GetComponent<SleepBehavior>().RequestWakeUp();
			break;
		default:
			base.FinalizeAction(action, naturalFinish);
			break;
		case DogAction.LAY_EGGS:
			break;
		}
	}

	public override bool IsRoomBehavior()
	{
		return true;
	}

	public override RoomBase GetTargetRoom()
	{
		return associatedAI.GetTargetRoom();
	}
}
