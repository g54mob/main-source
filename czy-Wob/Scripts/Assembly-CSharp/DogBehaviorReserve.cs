using System;
using UnityEngine;

[Serializable]
public class DogBehaviorReserve : DogBehaviorBase
{
	private DogBehaviorReserveEnum reserveEnum;

	public override DogBehaviorReserveEnum GetReserveEnum()
	{
		return reserveEnum;
	}

	protected override void AssignEnum()
	{
		base.AssignEnum();
		reserveEnum = (DogBehaviorReserveEnum)Enum.Parse(typeof(DogBehaviorReserveEnum), base.gameObject.name);
	}

	public override void StartBehavior()
	{
		if (!flipReservationRequirements)
		{
			associatedAI.GetTargetReservableObject().ReserveObject(dogRegRef.GetIDFromDog(associatedDog));
		}
		base.StartBehavior();
	}

	public override void FinishBehavior(bool naturalFinish = true, GameObject objectCause = null)
	{
		base.FinishBehavior(naturalFinish, objectCause);
		if (!flipReservationRequirements)
		{
			associatedAI.ClearTargetReservableObject();
		}
	}

	protected override bool NeedsCancel()
	{
		if (associatedAI.GetTargetReservableObject() == null)
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
			TargetPointHelper.TargetRoom(associatedDog, GetTargetReservableObject().transform.root.GetComponent<RoomBase>(), base.ActionFinishedCallback);
			break;
		case DogAction.WALK_TO_RESERVABLE_OBJECT:
			TargetPointHelper.TargetGivenPoint(associatedDog, GetTargetReservableObject().GetTargetTransform(), base.ActionFinishedCallback, targetReservableType);
			break;
		case DogAction.LAY_EGGS:
			associatedDog.GetComponent<DogEggLayingController>().LayEggs(base.ActionFinishedCallback);
			break;
		case DogAction.RUN_RESERVABLE_BEHAVIOR:
			RunReservableAction();
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
		case DogAction.WALK_TO_RESERVABLE_OBJECT:
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			break;
		case DogAction.RUN_RESERVABLE_BEHAVIOR:
			FinishReservableAction();
			break;
		default:
			base.FinalizeAction(action, naturalFinish);
			break;
		case DogAction.LAY_EGGS:
			break;
		}
	}

	public override bool IsReserveBehavior()
	{
		return true;
	}

	public override ReservableObject GetTargetReservableObject()
	{
		return associatedAI.GetTargetReservableObject();
	}

	protected virtual void RunReservableAction()
	{
		associatedAI.GetTargetReservableObject().OnConfirm(dogRegRef.GetIDFromDog(associatedDog), base.ActionFinishedCallback);
	}

	protected virtual void FinishReservableAction()
	{
		ReservableObject targetReservableObject = associatedAI.GetTargetReservableObject();
		if (!(targetReservableObject == null))
		{
			ulong iDFromDog = dogRegRef.GetIDFromDog(associatedDog);
			if (targetReservableObject.IsDogUsingObject(iDFromDog))
			{
				targetReservableObject.ReleaseObject(iDFromDog);
			}
		}
	}
}
