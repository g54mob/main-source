using System;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class Vector2Extensions
	{
		public static float RandomInRange(this Vector2 p_vector)
		{
			return UnityEngine.Random.Range(p_vector.x, p_vector.y);
		}

		public static Vector3 ToHorizontal3D(this Vector2 vector)
		{
			return new Vector3(vector.x, 0f, vector.y);
		}

		public static Vector3 ToScreenPoint(this Vector2 vector)
		{
			return new Vector3(vector.x, vector.y, 1f);
		}

		public static Vector2 RotateDirection(this Vector2 vector, float degrees)
		{
			float num = Mathf.Sin(degrees * (MathF.PI / 180f));
			float num2 = Mathf.Cos(degrees * (MathF.PI / 180f));
			float x = vector.x;
			float y = vector.y;
			vector.x = num2 * x - num * y;
			vector.y = num * x + num2 * y;
			return vector;
		}

		public static Vector2Int RoundToInt(this Vector2 vector)
		{
			return new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));
		}
	}
}
