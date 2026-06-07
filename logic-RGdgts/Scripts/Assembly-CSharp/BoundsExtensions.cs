using UnityEngine;

public static class BoundsExtensions
{
	public static string ToNiceString(this Bounds bounds)
	{
		return null;
	}

	public static bool Overlaps(this Bounds bounds, Bounds otherBounds)
	{
		return false;
	}

	public static Vector2 TopLeftCorner(this Bounds bounds)
	{
		return default(Vector2);
	}

	public static Vector2 TopRightCorner(this Bounds bounds)
	{
		return default(Vector2);
	}

	public static Vector2 BottomRightCorner(this Bounds bounds)
	{
		return default(Vector2);
	}

	public static Vector2 BottomLeftCorner(this Bounds bounds)
	{
		return default(Vector2);
	}

	public static float CalculateSphereRadius(this Bounds bounds)
	{
		return 0f;
	}

	public static bool ContainsBounds(this Bounds bounds, Bounds target)
	{
		return false;
	}
}
