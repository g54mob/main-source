using System;

namespace Febucci.Numbers
{
	public static class Mathf
	{
		public const float DEG2RAD = MathF.PI / 180f;

		private const float TOLERANCE = 1E-06f;

		public static float Clamp(float value, float min, float max)
		{
			if (!(value < min))
			{
				if (!(value > max))
				{
					return value;
				}
				return max;
			}
			return min;
		}

		public static float Clamp01(float value)
		{
			return Clamp(value, 0f, 1f);
		}

		public static float Lerp(float min, float max, float t)
		{
			return min + (max - min) * Clamp(t, 0f, 1f);
		}

		public static float LerpUnclamped(float min, float max, float t)
		{
			return min + (max - min) * t;
		}

		public static int Lerp(int min, int max, float t)
		{
			t = Clamp01(t);
			return (int)Math.Round((float)min + (float)(max - min) * t);
		}

		public static int LerpUnclamped(int min, int max, float t)
		{
			return (int)Math.Round((float)min + (float)(max - min) * t);
		}

		public static float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
		{
			float num = Clamp01((value - fromMin) / (fromMax - fromMin));
			return toMin + (toMax - toMin) * num;
		}

		public static float RemapUnclamped(float value, float fromMin, float fromMax, float toMin, float toMax)
		{
			float num = (value - fromMin) / (fromMax - fromMin);
			return toMin + (toMax - toMin) * num;
		}

		public static int Max(int a, int b)
		{
			if (a > b)
			{
				return a;
			}
			return b;
		}

		public static float Repeat(float t, float length)
		{
			return Clamp(t - (float)Math.Floor(t / length) * length, 0f, length);
		}

		public static Vector2 LerpTo(this Vector2 current, Vector2 other, float t)
		{
			return new Vector2(Lerp(current.X, other.X, t), Lerp(current.Y, other.Y, t));
		}

		public static Vector2 LerpUnclampedTo(this Vector2 current, Vector2 other, float t)
		{
			return new Vector2(LerpUnclamped(current.X, other.X, t), LerpUnclamped(current.Y, other.Y, t));
		}

		public static Vector3 LerpTo(this Vector3 current, Vector3 other, float t)
		{
			return new Vector3(Lerp(current.X, other.X, t), Lerp(current.Y, other.Y, t), Lerp(current.Z, other.Z, t));
		}

		public static Vector3 LerpUnclampedTo(this Vector3 current, Vector3 other, float t)
		{
			return new Vector3(LerpUnclamped(current.X, other.X, t), LerpUnclamped(current.Y, other.Y, t), LerpUnclamped(current.Z, other.Z, t));
		}

		public static Vector4 LerpTo(this Vector4 current, Vector4 other, float t)
		{
			return new Vector4(Lerp(current.X, other.X, t), Lerp(current.Y, other.Y, t), Lerp(current.Z, other.Z, t), Lerp(current.W, other.W, t));
		}

		public static Vector4 LerpUnclampedTo(this Vector4 current, Vector4 other, float t)
		{
			return new Vector4(LerpUnclamped(current.X, other.X, t), LerpUnclamped(current.Y, other.Y, t), LerpUnclamped(current.Z, other.Z, t), LerpUnclamped(current.W, other.W, t));
		}

		public static Color LerpTo(this Color current, Color other, float t)
		{
			return new Color(Lerp(current.X, other.X, t), Lerp(current.Y, other.Y, t), Lerp(current.Z, other.Z, t), Lerp(current.W, other.W, t));
		}

		public static Color LerpUnclampedTo(this Color current, Color other, float t)
		{
			return new Color(LerpUnclamped(current.X, other.X, t), LerpUnclamped(current.Y, other.Y, t), LerpUnclamped(current.Z, other.Z, t), LerpUnclamped(current.W, other.W, t));
		}

		public static Quaternion LerpTo(this Quaternion current, Quaternion other, float t)
		{
			return new Quaternion(Lerp(current.X, other.X, t), Lerp(current.Y, other.Y, t), Lerp(current.Z, other.Z, t), Lerp(current.W, other.W, t));
		}

		public static Quaternion LerpUnclampedTo(this Quaternion current, Quaternion other, float t)
		{
			return new Quaternion(LerpUnclamped(current.X, other.X, t), LerpUnclamped(current.Y, other.Y, t), LerpUnclamped(current.Z, other.Z, t), LerpUnclamped(current.W, other.W, t));
		}

		public static Quaternion Slerp(this Quaternion current, Quaternion target, float t)
		{
			t = Clamp01(t);
			return current.SlerpUnclamped(target, t);
		}

		public static Quaternion SlerpUnclamped(this Quaternion current, Quaternion target, float t)
		{
			float num = current.X * target.X + current.Y * target.Y + current.Z * target.Z + current.W * target.W;
			if (num < 0f)
			{
				target = new Quaternion(0f - target.X, 0f - target.Y, 0f - target.Z, 0f - target.W);
				num = 0f - num;
			}
			if (num > 0.9995f)
			{
				return new Quaternion(LerpUnclamped(current.X, target.X, t), LerpUnclamped(current.Y, target.Y, t), LerpUnclamped(current.Z, target.Z, t), LerpUnclamped(current.W, target.W, t)).normalized;
			}
			float num2 = (float)Math.Acos(num);
			float num3 = (float)Math.Sin(num2);
			float num4 = (float)Math.Sin((1f - t) * num2) / num3;
			float num5 = (float)Math.Sin(t * num2) / num3;
			return new Quaternion(num4 * current.X + num5 * target.X, num4 * current.Y + num5 * target.Y, num4 * current.Z + num5 * target.Z, num4 * current.W + num5 * target.W);
		}

		public static Vector2Int LerpTo(this Vector2Int current, Vector2Int other, float t)
		{
			return new Vector2Int(Lerp(current.X, other.X, t), Lerp(current.Y, other.Y, t));
		}

		public static Vector2Int LerpUnclampedTo(this Vector2Int current, Vector2Int other, float t)
		{
			return new Vector2Int(LerpUnclamped(current.X, other.X, t), LerpUnclamped(current.Y, other.Y, t));
		}

		public static Vector3Int LerpTo(this Vector3Int current, Vector3Int other, float t)
		{
			return new Vector3Int(Lerp(current.X, other.X, t), Lerp(current.Y, other.Y, t), Lerp(current.Z, other.Z, t));
		}

		public static Vector3Int LerpUnclampedTo(this Vector3Int current, Vector3Int other, float t)
		{
			return new Vector3Int(LerpUnclamped(current.X, other.X, t), LerpUnclamped(current.Y, other.Y, t), LerpUnclamped(current.Z, other.Z, t));
		}

		public static Vector4Int LerpTo(this Vector4Int current, Vector4Int other, float t)
		{
			return new Vector4Int(Lerp(current.X, other.X, t), Lerp(current.Y, other.Y, t), Lerp(current.Z, other.Z, t), Lerp(current.W, other.W, t));
		}

		public static Vector4Int LerpUnclampedTo(this Vector4Int current, Vector4Int other, float t)
		{
			return new Vector4Int(LerpUnclamped(current.X, other.X, t), LerpUnclamped(current.Y, other.Y, t), LerpUnclamped(current.Z, other.Z, t), LerpUnclamped(current.W, other.W, t));
		}

		public static bool ApproximatesTo(this Vector2 a, Vector2 b)
		{
			if (Math.Abs(a.X - b.X) < 1E-06f)
			{
				return Math.Abs(a.Y - b.Y) < 1E-06f;
			}
			return false;
		}

		public static bool ApproximatesTo(this Vector3 a, Vector3 b)
		{
			if (Math.Abs(a.X - b.X) < 1E-06f && Math.Abs(a.Y - b.Y) < 1E-06f)
			{
				return Math.Abs(a.Z - b.Z) < 1E-06f;
			}
			return false;
		}

		public static bool ApproximatesTo(this Vector4 a, Vector4 b)
		{
			if (Math.Abs(a.X - b.X) < 1E-06f && Math.Abs(a.Y - b.Y) < 1E-06f && Math.Abs(a.Z - b.Z) < 1E-06f)
			{
				return Math.Abs(a.W - b.W) < 1E-06f;
			}
			return false;
		}

		public static bool ApproximatesTo(this Color a, Color b)
		{
			if (Math.Abs(a.X - b.X) < 1E-06f && Math.Abs(a.Y - b.Y) < 1E-06f && Math.Abs(a.Z - b.Z) < 1E-06f)
			{
				return Math.Abs(a.W - b.W) < 1E-06f;
			}
			return false;
		}

		public static bool ApproximatesTo(this Quaternion a, Quaternion b)
		{
			if (Math.Abs(a.X - b.X) < 1E-06f && Math.Abs(a.Y - b.Y) < 1E-06f && Math.Abs(a.Z - b.Z) < 1E-06f)
			{
				return Math.Abs(a.W - b.W) < 1E-06f;
			}
			return false;
		}

		public static bool ApproximatesTo(this Vector2Int a, Vector2Int b)
		{
			if (a.X == b.X)
			{
				return a.Y == b.Y;
			}
			return false;
		}

		public static bool ApproximatesTo(this Vector3Int a, Vector3Int b)
		{
			if (a.X == b.X && a.Y == b.Y)
			{
				return a.Z == b.Z;
			}
			return false;
		}

		public static bool ApproximatesTo(this Vector4Int a, Vector4Int b)
		{
			if (a.X == b.X && a.Y == b.Y && a.Z == b.Z)
			{
				return a.W == b.W;
			}
			return false;
		}

		public static float PingPong(float t, float length)
		{
			t = Repeat(t, length * 2f);
			return length - Math.Abs(t - length);
		}
	}
}
