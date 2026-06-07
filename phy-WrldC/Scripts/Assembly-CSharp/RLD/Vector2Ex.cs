using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class Vector2Ex
	{
		public static Vector3 ConvertDirTo3D(Vector2 start, Vector2 end, Vector3 zPos, Camera camera)
		{
			float pointZDistance = camera.GetPointZDistance(zPos);
			Vector3 vector = camera.ScreenToWorldPoint(new Vector3(start.x, start.y, pointZDistance));
			return camera.ScreenToWorldPoint(new Vector3(end.x, end.y, pointZDistance)) - vector;
		}

		public static Vector3 ConvertDirTo3D(Vector2 dir, Vector3 zPos, Camera camera)
		{
			float pointZDistance = camera.GetPointZDistance(zPos);
			Vector3 vector = camera.ScreenToWorldPoint(new Vector3(0f, 0f, pointZDistance));
			return camera.ScreenToWorldPoint(new Vector3(dir.x, dir.y, pointZDistance)) - vector;
		}

		public static Vector2 Abs(this Vector2 v)
		{
			return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
		}

		public static float AbsDot(this Vector2 v1, Vector2 v2)
		{
			return Mathf.Abs(Vector2.Dot(v1, v2));
		}

		public static Vector3 ToVector3(this Vector2 vec, float z = 0f)
		{
			return new Vector3(vec.x, vec.y, z);
		}

		public static Vector2 GetNormal(this Vector2 vec)
		{
			return new Vector2(0f - vec.y, vec.x).normalized;
		}

		public static Vector2 FromValue(float value)
		{
			return new Vector2(value, value);
		}

		public static Vector2 GetInverse(this Vector2 vector)
		{
			return new Vector2(1f / vector.x, 1f / vector.y);
		}

		public static float GetDistanceToSegment(this Vector2 point, Vector2 point0, Vector2 point1)
		{
			Vector2 vector = point1 - point0;
			float magnitude = vector.magnitude;
			vector.Normalize();
			Vector2 rhs = point - point0;
			float num = Vector2.Dot(vector, rhs);
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

		public static int GetPointClosestToPoint(List<Vector2> points, Vector2 pt)
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
	}
}
