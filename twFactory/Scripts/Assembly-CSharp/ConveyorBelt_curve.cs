using System;
using UnityEngine;

public class ConveyorBelt_curve : ConveyorBelt
{
	[SerializeField]
	private float curveRadius = 1f;

	[SerializeField]
	private ConveyorBelt_straight conveyorBelt_StraightPrefab;

	[SerializeField]
	private ConveyorBelt_curve conveyorBelt_CurveRightPrefab;

	[SerializeField]
	private ConveyorBelt_curve conveyorBelt_CurveLeftPrefab;

	private Vector3 curvePivot;

	private Vector3 rotationAxis;

	private bool isLeftCurve;

	public ConveyorBelt_straight ConveyorBelt_StraightPrefab => conveyorBelt_StraightPrefab;

	public ConveyorBelt_curve ConveyorBelt_CurveRightPrefab => conveyorBelt_CurveRightPrefab;

	public ConveyorBelt_curve ConveyorBelt_CurveLeftPrefab => conveyorBelt_CurveLeftPrefab;

	public override void Awake()
	{
		base.Awake();
		UpdateCurvePivot();
	}

	public override float MovePosition(GameObject objectToMove, ref float maxDistance, ref float availableMovingTime)
	{
		float num = base.Speed * Mathf.Max(availableMovingTime, 0f);
		float num2 = num;
		num = Mathf.Min(num, GetDistanceFromEnd(objectToMove.transform.position));
		bool flag = num < num2;
		if (maxDistance < num)
		{
			availableMovingTime = 0f;
			num = maxDistance;
			flag = false;
		}
		else
		{
			availableMovingTime -= num / base.Speed;
			maxDistance -= num;
		}
		if (flag)
		{
			objectToMove.transform.position = GetEndPosition();
			objectToMove.transform.rotation = Quaternion.LookRotation(LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(base.OutputOrientation, base.RotationY)), base.transform.up);
		}
		else
		{
			objectToMove.transform.RotateAround(curvePivot, rotationAxis, GetDegreesByLinearDistance(num));
		}
		return num;
	}

	protected override float GetDistanceFromEnd(Vector3 position)
	{
		return GetDistanceByAngle(Vector3.SignedAngle(position - curvePivot, GetEndPosition() - curvePivot, base.transform.up) * (float)((!isLeftCurve) ? 1 : (-1)));
	}

	private void UpdateCurvePivot()
	{
		curvePivot = base.transform.TransformPoint(LTFunctionLibrary.GetDirectionFromOrientation(base.InputOrientation) * 0.5f + LTFunctionLibrary.GetDirectionFromOrientation(base.OutputOrientation) * 0.5f);
		isLeftCurve = Vector3.SignedAngle(LTFunctionLibrary.GetDirectionFromOrientation(base.InputOrientation), LTFunctionLibrary.GetDirectionFromOrientation(base.OutputOrientation), base.transform.up) > 0f;
	}

	public override float GetBeltDistance()
	{
		return GetDistanceByAngle(90f);
	}

	private float GetDistanceByAngle(float degrees)
	{
		return Mathf.Max(degrees * (MathF.PI / 180f) * curveRadius, 0f);
	}

	private float GetDegreesByLinearDistance(float linearDistance)
	{
		return linearDistance / curveRadius * 57.29578f;
	}

	protected override void UpdateConveyorBeltType()
	{
		ConveyorBelt conveyorBelt = null;
		bool flag = false;
		foreach (ConveyorBelt adjacentBuiltObject in LTFunctionLibrary.GetGrid().GetAdjacentBuiltObjects<ConveyorBelt>(base.transform))
		{
			if (LTFunctionLibrary.GetOrientationDot(LTFunctionLibrary.OrientationToWorldSpace(base.OutputOrientation, base.transform), LTFunctionLibrary.GetOrientationBetweenPositions(base.transform.position, adjacentBuiltObject.transform.position)) != 1f && LTFunctionLibrary.GetOrientationDot(LTFunctionLibrary.OrientationToWorldSpace(adjacentBuiltObject.OutputOrientation, adjacentBuiltObject.transform), LTFunctionLibrary.GetOrientationBetweenPositions(adjacentBuiltObject.transform.position, base.transform.position)) == 1f)
			{
				if (conveyorBelt != null)
				{
					flag = true;
				}
				conveyorBelt = adjacentBuiltObject;
			}
		}
		PlacementComponent placementComponent = null;
		if ((bool)conveyorBelt && !flag)
		{
			EOrientation eOrientation = LTFunctionLibrary.OrientationToLocalSpace(LTFunctionLibrary.GetOrientationBetweenPositions(base.transform.position, conveyorBelt.transform.position), base.transform);
			if (eOrientation == EOrientation.East && isLeftCurve)
			{
				placementComponent = UnityEngine.Object.Instantiate(conveyorBelt_CurveRightPrefab, base.transform.position, base.transform.rotation, base.transform.parent).GetComponent<PlacementComponent>();
			}
			else if (eOrientation == EOrientation.West && !isLeftCurve)
			{
				placementComponent = UnityEngine.Object.Instantiate(conveyorBelt_CurveLeftPrefab, base.transform.position, base.transform.rotation, base.transform.parent).GetComponent<PlacementComponent>();
			}
			else if (eOrientation != EOrientation.East && eOrientation != EOrientation.West)
			{
				placementComponent = UnityEngine.Object.Instantiate(ConveyorBelt_StraightPrefab, base.transform.position, base.transform.rotation, base.transform.parent).GetComponent<PlacementComponent>();
			}
		}
		else
		{
			placementComponent = UnityEngine.Object.Instantiate(ConveyorBelt_StraightPrefab, base.transform.position, base.transform.rotation, base.transform.parent).GetComponent<PlacementComponent>();
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
		UpdateCurvePivot();
		rotationAxis = Vector3.Cross(LTFunctionLibrary.GetDirectionFromOrientation(base.OutputOrientation), LTFunctionLibrary.GetDirectionFromOrientation(base.InputOrientation));
	}
}
