using UnityEngine;

public class InteractibleDogDen : InteractableBase
{
	public Transform interactionPoint;

	public override Vector3 GetInteractionPoint()
	{
		return interactionPoint.position;
	}

	public override Transform GetInteractionPointTransform()
	{
		return interactionPoint;
	}

	public override bool HasCustomInteractionPoint()
	{
		return true;
	}

	public override Transform GetFocusTransform()
	{
		return interactionPoint;
	}
}
