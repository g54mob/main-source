using UnityEngine;

public class RaycastHitPointInfo
{
	public GameObject castedObject;

	public Vector3 hitPointPosition;

	public Vector3 hitPointNormal;

	public bool IsHitPointSurfaceUpwards(float threshold = 0.1f)
	{
		if (Vector3.Dot(Vector3.up, hitPointNormal) >= 1f - threshold)
		{
			return true;
		}
		return false;
	}
}
