using UnityEngine;

public static class BoundsExtension
{
	public static Vector3 ToVector3(this Vector2 parent)
	{
		return default(Vector3);
	}

	public static void Encapsulate(this ref BoundsInt b, Vector3Int point)
	{
	}

	public static void Encapsulate(this ref BoundsInt b, BoundsInt bounds)
	{
	}
}
