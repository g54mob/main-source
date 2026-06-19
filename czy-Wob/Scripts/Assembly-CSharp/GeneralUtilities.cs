using UnityEngine;

public static class GeneralUtilities
{
	public static bool PointInsideTriangle(Vector2 p, Vector2 p0, Vector2 p1, Vector2 p2)
	{
		Vector2 vector = p2 - p0;
		Vector2 vector2 = p1 - p0;
		Vector2 rhs = p - p0;
		float num = Vector2.Dot(vector, vector);
		float num2 = Vector2.Dot(vector, vector2);
		float num3 = Vector2.Dot(vector, rhs);
		float num4 = Vector2.Dot(vector2, vector2);
		float num5 = Vector2.Dot(vector2, rhs);
		float num6 = 1f / (num * num4 - num2 * num2);
		float num7 = (num4 * num3 - num2 * num5) * num6;
		float num8 = (num * num5 - num2 * num3) * num6;
		if (num7 >= 0f && num8 >= 0f)
		{
			return num7 + num8 < 1f;
		}
		return false;
	}

	public static float AngleBetweenVectors(Vector2 u, Vector2 v)
	{
		return ((u.x * v.y - u.y * v.x > 0f) ? 1f : (-1f)) * Mathf.Acos(Vector2.Dot(u, v) / (u.magnitude * v.magnitude));
	}
}
