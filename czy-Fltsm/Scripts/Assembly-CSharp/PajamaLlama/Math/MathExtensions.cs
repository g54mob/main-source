using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Math
{
	public static class MathExtensions
	{
		private static Rectangle _tempPolygon = new Rectangle();

		public static Vector3 Vector3TopDown(this Vector2 vector, float y = 0f)
		{
			return new Vector3(vector.x, y, vector.y);
		}

		public static Vector3 Vector3TopDown(this Vector3 vector)
		{
			return new Vector3(vector.x, 0f, vector.z);
		}

		public static Vector2 Normalize(this Vector2 vector)
		{
			float x = vector.x;
			float y = vector.y;
			float num = Mathf.Sqrt(x * x + y * y);
			return new Vector2(x / num, y / num);
		}

		public static float DistanceToSquared(this Vector2 from, Vector2 to)
		{
			float num = to.x - from.x;
			float num2 = to.y - from.y;
			return num * num + num2 * num2;
		}

		public static float DistanceToSquared(this Vector2 from, float pointX, float pointY)
		{
			float num = pointX - from.x;
			float num2 = pointY - from.y;
			return num * num + num2 * num2;
		}

		public static bool IsInRange(this Vector2 from, Vector2 to, float distance)
		{
			float num = to.x - from.x;
			float num2 = to.y - from.y;
			return num * num + num2 * num2 < distance * distance;
		}

		public static float Angle(this Vector2 from, Vector2 to)
		{
			float x = from.x;
			float y = from.y;
			float num = Mathf.Sqrt(x * x + y * y);
			float num2 = x / num;
			y /= num;
			float x2 = to.x;
			float y2 = to.y;
			float num3 = Mathf.Sqrt(x2 * x2 + y2 * y2);
			x2 /= num3;
			y2 /= num3;
			return Mathf.Acos(num2 * x2 + y * y2) * 57.29578f;
		}

		public static float Cross(this Vector2 left, Vector2 right)
		{
			return left.x * right.y - right.x * left.y;
		}

		public static Vector2 Average(this IReadOnlyList<Vector2> vectors)
		{
			if (vectors == null || vectors.Count == 0)
			{
				return Vector2.zero;
			}
			float num = 0f;
			float num2 = 0f;
			foreach (Vector2 vector in vectors)
			{
				num += vector.x;
				num2 += vector.y;
			}
			return new Vector2(num / (float)vectors.Count, num2 / (float)vectors.Count);
		}

		public static bool Approximately(this Vector2 vector, Vector2 other, float margin)
		{
			margin *= margin;
			return (vector - other).sqrMagnitude < margin;
		}

		public static Vector2 Vector2TopDown(this Vector3 vector)
		{
			return new Vector2(vector.x, vector.z);
		}

		public static Vector3 SetX(this Vector3 vector, float x)
		{
			return new Vector3(x, vector.y, vector.z);
		}

		public static Vector3 SetY(this Vector3 vector, float y)
		{
			return new Vector3(vector.x, y, vector.z);
		}

		public static Vector3 SetZ(this Vector3 vector, float z)
		{
			return new Vector3(vector.x, vector.y, z);
		}

		public static bool IsEqual(this Vector3 vectorA, Vector3 vectorB)
		{
			if (Mathf.Approximately(vectorA.x, vectorB.x) && Mathf.Approximately(vectorA.y, vectorB.y))
			{
				return Mathf.Approximately(vectorA.z, vectorB.z);
			}
			return false;
		}

		public static Vector3 Leveled(this Vector3 vector)
		{
			return new Vector3(vector.x, 0f, vector.z);
		}

		public static Vector3 Multiply(this Vector3 vector, Vector3 multipliedVector)
		{
			return new Vector3(vector.x * multipliedVector.x, vector.y * multipliedVector.y, vector.z * multipliedVector.z);
		}

		public static bool IsInRange(this Vector3 me, Vector3 center, float distance)
		{
			float num = center.x - me.x;
			float num2 = center.y - me.y;
			float num3 = center.z - me.z;
			return num * num + num2 * num2 + num3 * num3 < distance * distance;
		}

		public static bool IsInRangeXZ(this Vector3 me, Vector3 point, float distance)
		{
			float num = point.x - me.x;
			float num2 = point.z - me.z;
			return num * num + num2 * num2 < distance * distance;
		}

		public static float FastMagnitudeLeveled(this Vector3 me)
		{
			float x = me.x;
			float z = me.z;
			return Mathf.Sqrt(x * x + z * z);
		}

		public static float FastSquaredMagnitudeLeveled(this Vector3 me)
		{
			float x = me.x;
			float z = me.z;
			return x * x + z * z;
		}

		public static float DistanceToLeveled(this Vector3 from, Vector3 to)
		{
			float num = to.x - from.x;
			float num2 = to.z - from.z;
			return Mathf.Sqrt(num * num + num2 * num2);
		}

		public static float DistanceToLeveledSquared(this Vector3 from, Vector3 to)
		{
			float num = to.x - from.x;
			float num2 = to.z - from.z;
			return num * num + num2 * num2;
		}

		public static float DistanceToSquared(this Vector3 from, Vector3 to)
		{
			float num = to.x - from.x;
			float num2 = to.y - from.y;
			float num3 = to.z - from.z;
			return num * num + num2 * num2 + num3 * num3;
		}

		public static bool Approximately(this Vector3 left, Vector3 right)
		{
			if (Mathf.Approximately(left.x, right.x) && Mathf.Approximately(left.y, right.y))
			{
				return Mathf.Approximately(left.z, right.z);
			}
			return false;
		}

		public static bool Approximately(float a, float b, float tolerance = 0.0001f)
		{
			if (a >= b - tolerance && a <= b + tolerance)
			{
				return true;
			}
			return false;
		}

		public static float AddAndRoundToMultiple(float value, float amountToAdd)
		{
			float num = Mathf.Abs(amountToAdd);
			if (amountToAdd <= 10f)
			{
				return (float)Mathf.CeilToInt((value + amountToAdd) / num) * num;
			}
			if (amountToAdd >= 10f)
			{
				return (float)Mathf.FloorToInt((value + amountToAdd) / num) * num;
			}
			return value + amountToAdd;
		}

		public static byte Add(this byte left, int right)
		{
			return (byte)(left + right);
		}

		public static Rect Add(this Rect rect, Rect rectToAdd)
		{
			return Rect.MinMaxRect(Mathf.Min(rect.xMin, rectToAdd.xMin), Mathf.Min(rect.yMin, rectToAdd.yMin), Mathf.Max(rect.xMax, rectToAdd.xMax), Mathf.Max(rect.yMax, rectToAdd.yMax));
		}

		public static Polygon2DBase GetTempPolygon(this Rect rect)
		{
			_tempPolygon.Set(rect);
			return _tempPolygon;
		}
	}
}
