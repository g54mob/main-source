using UnityEngine;

public static class Vector3Extensions
{
	public static Vector3 Flattened(this Vector3 vector)
	{
		return default(Vector3);
	}

	public static float DistanceFlat(this Vector3 origin, Vector3 destination)
	{
		return 0f;
	}

	public static Vector2 ToVector2(this Vector3 v)
	{
		return default(Vector2);
	}

	public static Vector3Int ToVector3Int(this Vector3 v)
	{
		return default(Vector3Int);
	}

	public static Vector3 WithX(this Vector3 v, float x)
	{
		return default(Vector3);
	}

	public static Vector3 WithY(this Vector3 v, float y)
	{
		return default(Vector3);
	}

	public static Vector3 WithZ(this Vector3 v, float z)
	{
		return default(Vector3);
	}

	public static Vector2 WithX(this Vector2 v, float x)
	{
		return default(Vector2);
	}

	public static Vector2 WithY(this Vector2 v, float y)
	{
		return default(Vector2);
	}

	public static Vector3 WithXZ(this Vector3 v, float x, float z)
	{
		return default(Vector3);
	}

	public static Vector3Int WithX(this Vector3Int v, int x)
	{
		return default(Vector3Int);
	}

	public static Vector3Int WithY(this Vector3Int v, int y)
	{
		return default(Vector3Int);
	}

	public static Vector3Int WithZ(this Vector3Int v, int z)
	{
		return default(Vector3Int);
	}

	public static Vector3 NearestPointOnAxis(this Vector3 axisDirection, Vector3 point, bool isNormalized = false)
	{
		return default(Vector3);
	}

	public static Vector3 NearestPointOnLine(this Vector3 lineDirection, Vector3 point, Vector3 pointOnLine, bool isNormalized = false)
	{
		return default(Vector3);
	}

	public static Vector2[] ToVector2Array(this Vector3[] v3)
	{
		return null;
	}

	public static Vector2 GetV3fromV2(Vector3 v3)
	{
		return default(Vector2);
	}

	public static Vector3[] ToVector3Array(this Vector2[] v2)
	{
		return null;
	}

	public static Vector3 GetV2fromV3(Vector2 v2)
	{
		return default(Vector3);
	}
}
