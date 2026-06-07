using UnityEngine;

public static class Vector2Extensions
{
	public static Vector2 Rotated(this Vector2 vector, float angle)
	{
		float num = Mathf.Sin(angle);
		float num2 = Mathf.Cos(angle);
		return new Vector2(num2 * vector.x - num * vector.y, num * vector.x + num2 * vector.y);
	}

	public static Vector2 GetTangent(this Vector2 vector2)
	{
		return new Vector2(vector2.y, 0f - vector2.x);
	}

	public static Vector2 GetNormal(this Vector2 vector2)
	{
		return vector2.GetTangent();
	}

	public static float Cross(this Vector2 lhs, Vector2 rhs)
	{
		return lhs.x * rhs.y - lhs.y * rhs.x;
	}

	public static Vector2Int GetNegatedVector(this Vector2Int vector2Int)
	{
		return new Vector2Int(-vector2Int.x, -vector2Int.y);
	}

	public static Vector3 ToVector3(this Vector2Int vector2Int)
	{
		return new Vector3(vector2Int.x, vector2Int.y, 0f);
	}
}
