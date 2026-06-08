using UnityEngine;

public static class VectorExtensions
{
	public static Vector3 RotateZ(this Vector3 v, float angle)
	{
		return Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f)) * v;
	}
}
