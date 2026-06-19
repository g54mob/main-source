using UnityEngine;

public class InteractibleFoodDispensor : InteractableBase
{
	public InchwormBounce bounceRef;

	public FoodDispensor dispensorRef;

	public Transform interactionPoint;

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		OnDispenseButtonPressed();
	}

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

	public void OnDispenseButtonPressed()
	{
		bounceRef.RequestBounce();
		dispensorRef.OnDispenseButtonPressed();
	}
}
