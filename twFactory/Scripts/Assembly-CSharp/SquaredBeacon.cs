using UnityEngine;

public class SquaredBeacon : Beacon
{
	[SerializeField]
	private float width;

	[SerializeField]
	private float length;

	protected override void InstantiateFogOfWarPrefab()
	{
		Object.Instantiate(fowAreaPrefab, placementComponent.GetCenter() + Vector3.up * 5f, base.transform.rotation, base.transform).transform.localScale = new Vector3(width, 1f, length + 0.5f);
	}

	protected override void ShowRangeIndicator()
	{
		LTFunctionLibrary.GetLTGameManager().ShowSquaredRangeIndicator(placementComponent.GetCenter(), width, length, base.transform.rotation * Vector3.forward);
	}
}
