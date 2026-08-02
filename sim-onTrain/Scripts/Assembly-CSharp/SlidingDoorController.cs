using DG.Tweening;
using UnityEngine;

public class SlidingDoorController : DoorBase
{
	public Transform doorPart;

	public Vector3 startPosition;

	public Vector3 targetPosition;

	protected override void Start()
	{
		movementType = DoorMovementType.Slide;
		base.Start();
		if (startPosition == Vector3.zero)
		{
			startPosition = doorPart.localPosition;
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
		doorPart.DOKill();
		doorPart.DOLocalMove(targetPosition, openingTime);
	}

	public override void CloseDoor()
	{
		doorPart.DOKill();
		doorPart.DOLocalMove(startPosition, openingTime);
	}

	public override bool Weaved()
	{
		return true;
	}
}
