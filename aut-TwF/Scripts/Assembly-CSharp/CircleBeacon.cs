using UnityEngine;

public class CircleBeacon : Beacon
{
	[SerializeField]
	protected float radius = 1f;

	protected override void InstantiateFogOfWarPrefab()
	{
		Object.Instantiate(fowAreaPrefab, placementComponent.GetCenter() + Vector3.up * 5f, Quaternion.identity, base.transform).transform.localScale = Vector3.one * radius;
	}

	protected override void ShowRangeIndicator()
	{
		LTFunctionLibrary.GetLTGameManager().ShowCircleRangeIndicator(placementComponent.GetCenter(), radius, 0f);
	}
}
