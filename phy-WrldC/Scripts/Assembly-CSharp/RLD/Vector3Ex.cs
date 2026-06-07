using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class Vector3Ex
	{
		public static void OffsetPoints(List<Vector3> points, Vector3 offset)
		{
			for (int i = 0; i < points.Count; i++)
			{
				points[i] += offset;
			}
		}

		public static Vector2 ConvertDirTo2D(Vector3 start, Vector3 end, Camera camera)
		{
			Vector2 vector = camera.WorldToScreenPoint(start);
			return (Vector2)camera.WorldToScreenPoint(end) - vector;
		}

		public static Vector3 Abs(this Vector3 v)
		{
			return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
		}

		public static Vector3 GetSignVector(this Vector3 v)
		{
			return new Vector3(Mathf.Sign(v.x), Mathf.Sign(v.y), Mathf.Sign(v.z));
		}

		public static float GetMaxAbsComp(this Vector3 v)
		{
			float num = Mathf.Abs(v.x);
			float num2 = Mathf.Abs(v.y);
			if (num2 > num)
			{
				num = num2;
			}
			float num3 = Mathf.Abs(v.z);
			if (num3 > num)
			{
				num = num3;
			}
			return num;
		}

		public static float Dot(this Vector3 v1, Vector3 v2)
		{
			return Vector3.Dot(v1, v2);
		}

		public static float AbsDot(this Vector3 v1, Vector3 v2)
		{
			return Mathf.Abs(Vector3.Dot(v1, v2));
		}

		public static Vector3 FromValue(float value)
		{
			return new Vector3(value, value, value);
		}

		public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
		{
			float num = Vector3.Dot(from.normalized, to.normalized);
			if (1f - num < 1E-05f)
			{
				return 0f;
			}
			if (1f + num < 1E-05f)
			{
				return 180f;
			}
			Vector3 normalized = Vector3.Cross(from, to).normalized;
			float num2 = MathEx.SafeAcos(num) * 57.29578f;
			if (Vector3.Dot(normalized, axis) < 0f)
			{
				num2 = 0f - num2;
			}
			return num2;
		}

		public static float GetDistanceToSegment(this Vector3 point, Vector3 point0, Vector3 point1)
		{
			Vector3 vector = point1 - point0;
			float magnitude = vector.magnitude;
			vector.Normalize();
			Vector3 rhs = point - point0;
			float num = Vector3.Dot(vector, rhs);
			if (num >= 0f && num <= magnitude)
			{
				return (point0 + vector * num - point).magnitude;
			}
			if (num < 0f)
			{
				return rhs.magnitude;
			}
			return (point1 - point).magnitude;
		}

		public static Vector3 ProjectOnSegment(this Vector3 point, Vector3 point0, Vector3 point1)
		{
			Vector3 normalized = (point1 - point0).normalized;
			return point0 + normalized * Vector3.Dot(point - point0, normalized);
		}

		public static int GetPointClosestToPoint(List<Vector3> points, Vector3 pt)
		{
			float num = float.MaxValue;
			int result = -1;
			for (int i = 0; i < points.Count; i++)
			{
				float sqrMagnitude = (points[i] - pt).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = i;
				}
			}
			return result;
		}

		public static Vector3 GetPointCloudCenter(IEnumerable<Vector3> ptCloud)
		{
			Vector3 vector = FromValue(float.MinValue);
			Vector3 vector2 = FromValue(float.MaxValue);
			foreach (Vector3 item in ptCloud)
			{
				vector = Vector3.Max(vector, item);
				vector2 = Vector3.Min(vector2, item);
			}
			return (vector + vector2) * 0.5f;
		}

		public static Vector3 GetInverse(this Vector3 vector)
		{
			return new Vector3(1f / vector.x, 1f / vector.y, 1f / vector.z);
		}

		public static bool IsAligned(this Vector3 vector, Vector3 other, bool checkSameDirection)
		{
			if (!checkSameDirection)
			{
				return Mathf.Abs(vector.AbsDot(other) - 1f) < 1E-05f;
			}
			float num = vector.Dot(other);
			if (num > 0f)
			{
				return Mathf.Abs(num - 1f) < 1E-05f;
			}
			return false;
		}

		public static bool PointsSameDir(this Vector3 vector, Vector3 other)
		{
			return vector.Dot(other) > 0f;
		}

		public static int GetMostAligned(Vector3[] vectors, Vector3 dir, bool checkSameDirection)
		{
			if (vectors.Length == 0)
			{
				return -1;
			}
			float num = float.MinValue;
			int result = -1;
			if (!checkSameDirection)
			{
				for (int i = 0; i < vectors.Length; i++)
				{
					float num2 = vectors[i].AbsDot(dir);
					if (num2 > num)
					{
						num = num2;
						result = i;
					}
				}
				return result;
			}
			for (int j = 0; j < vectors.Length; j++)
			{
				float num3 = vectors[j].Dot(dir);
				if (num3 > 0f && num3 > num)
				{
					num = num3;
					result = j;
				}
			}
			return result;
		}
	}
}
