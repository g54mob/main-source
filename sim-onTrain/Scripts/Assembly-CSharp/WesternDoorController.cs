using DG.Tweening;
using UnityEngine;

public class WesternDoorController : DoorBase
{
	public Transform leftPart;

	public Transform rightPart;

	public Vector3 leftPartStartPos;

	public Vector3 rightPartStartPos;

	public Vector3 leftPartTargetPos;

	public Vector3 rightPartTargetPos;

	protected override void Start()
	{
		movementType = DoorMovementType.Rotate;
		base.Start();
	}

	public override int GetClosestLeafIndex(Vector3 worldPos)
	{
		float num = ((leftPart != null) ? (leftPart.position - worldPos).sqrMagnitude : float.MaxValue);
		float num2 = ((rightPart != null) ? (rightPart.position - worldPos).sqrMagnitude : float.MaxValue);
		if (num == float.MaxValue && num2 == float.MaxValue)
		{
			return -1;
		}
		if (!(num <= num2))
		{
			return 1;
		}
		return 0;
	}

	public override Transform GetMovingPart(int index)
	{
		if (index != 1)
		{
			return leftPart;
		}
		return rightPart;
	}

	public override void OpenDoor()
	{
		if (rightPart != null)
		{
			rightPart.DOLocalRotate(rightPartTargetPos, openingTime);
		}
		if (leftPart != null)
		{
			leftPart.DOLocalRotate(leftPartTargetPos, openingTime);
		}
	}

	public override void CloseDoor()
	{
		if (rightPart != null)
		{
			rightPart.DOLocalRotate(rightPartStartPos, openingTime);
		}
		if (leftPart != null)
		{
			leftPart.DOLocalRotate(leftPartStartPos, openingTime);
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
