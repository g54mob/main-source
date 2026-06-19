using System;
using UnityEngine;

[Serializable]
public class DogBehaviorCreateBuildableObject : DogBehaviorBase
{
	public RoomBase storedRoom;

	public int storedRotationValue;

	public Vector2Int storedGridPos;

	public RoomCustomizationObject storedCustomizationObject;

	public GameObject temporaryFocusTarget;

	public bool handleDenAreaRegistration;

	public override void FinishBehavior(bool naturalFinish = true, GameObject objectCause = null)
	{
		base.FinishBehavior(naturalFinish, objectCause);
		if (temporaryFocusTarget != null)
		{
			UnityEngine.Object.Destroy(temporaryFocusTarget);
			temporaryFocusTarget = null;
		}
		if (storedRoom != null)
		{
			storedRoom.ReleaseAllTilesDogHasReservedForPlacement(dogRegRef.GetIDFromDog(associatedDog));
			if (handleDenAreaRegistration)
			{
				DogDenManager.UnregisterDogClearingArea(storedRoom.GetComponent<BuildObjectInfo>().GetUID());
			}
			storedRoom = null;
		}
		storedRotationValue = 0;
		storedGridPos = Vector2Int.zero;
		storedCustomizationObject = null;
		handleDenAreaRegistration = false;
	}

	public void StoreRoomCustomizationObject(RoomCustomizationObject newObj, RoomBase placementRoom, Vector2Int gridPos, int rotationValue = 0, bool clearingDenArea = false)
	{
		storedGridPos = gridPos;
		storedRoom = placementRoom;
		storedCustomizationObject = newObj;
		storedRotationValue = rotationValue;
		temporaryFocusTarget = new GameObject();
		temporaryFocusTarget.transform.position = storedPosition;
		if (clearingDenArea)
		{
			if (storedRoom == null)
			{
				Debug.LogError("In order to clear a den area, a valid room must be stored.");
				return;
			}
			handleDenAreaRegistration = true;
			DogDenManager.RegisterDogClearingArea(placementRoom.GetComponent<BuildObjectInfo>().GetUID());
		}
	}

	public void RepositionFocusTarget(Vector3 centerPos)
	{
		temporaryFocusTarget.transform.position = centerPos;
	}

	protected override void RunAction(DogAction action)
	{
		runningAction = true;
		switch (action)
		{
		case DogAction.RESERVE_DEN_AREA:
			associatedDog.GetComponent<DogDenController>().ReserveDenArea();
			ActionFinishedCallback();
			break;
		case DogAction.CREATE_DEN:
			associatedDog.GetComponent<DogDenController>().CreateDen();
			ActionFinishedCallback();
			break;
		case DogAction.RESERVE_HOLE_AREA:
			associatedDog.GetComponent<DogDenController>().ReserveHoleArea();
			ActionFinishedCallback();
			break;
		case DogAction.CREATE_HOLE:
			associatedDog.GetComponent<DogDenController>().CreateHole();
			ActionFinishedCallback();
			break;
		default:
			base.RunAction(action);
			break;
		}
	}

	protected override void FinalizeAction(DogAction action, bool naturalFinish)
	{
		base.FinalizeAction(action, naturalFinish);
	}

	public override bool IsCreateBuildableObjectBehavior()
	{
		return true;
	}

	public override bool InternalStartConditionsMet()
	{
		if (TutorialController.IsTutorialActive())
		{
			return false;
		}
		return base.InternalStartConditionsMet();
	}
}
