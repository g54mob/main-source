using UnityEngine;

public class ConeBeacon : Beacon
{
	[SerializeField]
	protected float radius = 1f;

	[SerializeField]
	private float degrees = 360f;

	protected override void ShowRangeIndicator()
	{
		LTFunctionLibrary.GetLTGameManager().ShowConeRangeIndicator(placementComponent.GetCenter(), radius, 0f, base.transform.forward, degrees);
	}
}
