using DG.Tweening;
using UnityEngine;

public class RampDoorController : DoorBase
{
	public Transform doorPart;

	public Vector3 doorStartPos;

	public Vector3 doorTargetPos;

	protected override void Start()
	{
		movementType = DoorMovementType.Rotate;
		base.Start();
		if (doorStartPos == Vector3.zero && doorPart != null)
		{
			doorStartPos = doorPart.localEulerAngles;
		}
	}

	public override int GetClosestLeafIndex(Vector3 worldPos)
	{
		if (!(doorPart != null))
		{
			return -1;
		}
		return 0;
	}

	public override Transform GetMovingPart(int index)
	{
		return doorPart;
	}

	public override void OpenDoor()
	{
		if (doorPart != null)
		{
			doorPart.DOLocalRotate(doorTargetPos, openingTime);
		}
	}

	public override void CloseDoor()
	{
		if (doorPart != null)
		{
			doorPart.DOLocalRotate(doorStartPos, openingTime);
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
