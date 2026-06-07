using UnityEngine;

public class ConveyorBelt_straight : ConveyorBelt
{
	[SerializeField]
	private ConveyorBelt_curve conveyorBelt_CurveRightPrefab;

	[SerializeField]
	private ConveyorBelt_curve conveyorBelt_CurveLeftPrefab;

	protected Vector3 movingDirection;

	private Vector3 auxVec;

	public override float MovePosition(GameObject objectToMove, ref float maxDistance, ref float availableMovingTime)
	{
		float a = base.Speed * Mathf.Max(availableMovingTime, 0f);
		a = Mathf.Min(a, GetDistanceFromEnd(objectToMove.transform.position));
		if (maxDistance <= a)
		{
			availableMovingTime = 0f;
			a = maxDistance;
		}
		else
		{
			availableMovingTime -= a / base.Speed;
			maxDistance -= a;
		}
		auxVec = objectToMove.transform.position + movingDirection * a;
		auxVec.y = base.transform.position.y + base.Height;
		objectToMove.transform.position = auxVec;
		return a;
	}

	protected override float GetDistanceFromEnd(Vector3 position)
	{
		auxVec = GetEndPosition() - position;
		return Mathf.Abs(auxVec.x + auxVec.z);
	}

	public override float GetBeltDistance()
	{
		return 1f;
	}

	protected virtual void UpdateMovingDirection()
	{
		movingDirection = LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(base.OutputOrientation, base.RotationY));
	}

	protected override void UpdateConveyorBeltType()
	{
		ConveyorBelt conveyorBelt = null;
		foreach (ConveyorBelt adjacentBuiltObject in LTFunctionLibrary.GetGrid().GetAdjacentBuiltObjects<ConveyorBelt>(base.transform))
		{
			if (LTFunctionLibrary.GetOrientationDot(LTFunctionLibrary.OrientationToWorldSpace(base.OutputOrientation, base.transform), LTFunctionLibrary.GetOrientationBetweenPositions(base.transform.position, adjacentBuiltObject.transform.position)) != 1f && LTFunctionLibrary.GetOrientationDot(LTFunctionLibrary.OrientationToWorldSpace(adjacentBuiltObject.OutputOrientation, adjacentBuiltObject.transform), LTFunctionLibrary.GetOrientationBetweenPositions(adjacentBuiltObject.transform.position, base.transform.position)) == 1f)
			{
				if (conveyorBelt != null)
				{
					return;
				}
				conveyorBelt = adjacentBuiltObject;
			}
		}
		if (!conveyorBelt)
		{
			return;
		}
		PlacementComponent placementComponent = null;
		switch (LTFunctionLibrary.OrientationToLocalSpace(LTFunctionLibrary.GetOrientationBetweenPositions(base.transform.position, conveyorBelt.transform.position), base.transform))
		{
		case EOrientation.East:
			placementComponent = Object.Instantiate(conveyorBelt_CurveRightPrefab, base.transform.position, base.transform.rotation, base.transform.parent).GetComponent<PlacementComponent>();
			break;
		case EOrientation.West:
			placementComponent = Object.Instantiate(conveyorBelt_CurveLeftPrefab, base.transform.position, base.transform.rotation, base.transform.parent).GetComponent<PlacementComponent>();
			break;
		}
		if ((bool)placementComponent)
		{
			if (base.PlacementComponent.IsPlaced)
			{
				updateNearbyConveyorsOnUnplace = false;
				base.PlacementComponent.Unplace();
				placementComponent.Place();
			}
			base.PlacementComponent.DestroyAndSubstitute(placementComponent);
		}
	}

	protected override void OnPlace(PlacementComponent placementComponent)
	{
		base.OnPlace(placementComponent);
		UpdateMovingDirection();
	}
}
