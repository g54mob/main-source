using System.Collections.Generic;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.UnityUtils
{
	public static class Mathv
	{
		public static int GetNearestEdge(IList<Vector3> polygon, Vector3 point, float maxDistance = float.PositiveInfinity, int startEdgeIndex = 0)
		{
			float num = float.MaxValue;
			int result = -1;
			if (polygon.Count <= 1)
			{
				return -1;
			}
			if (polygon.Count <= 2)
			{
				return 0;
			}
			for (int i = startEdgeIndex; i < polygon.Count - 1; i++)
			{
				Vector3 vector = polygon[i + 1] - polygon[i];
				float sqrMagnitude = vector.sqrMagnitude;
				float num2 = Vector3.Dot(point - polygon[i], vector) / sqrMagnitude;
				float num3 = Vector3.Distance(polygon[i] + Mathf.Clamp01(num2) * vector, point);
				if (num2 >= 0f && num2 <= 1f && num3 < maxDistance)
				{
					return i;
				}
				if (num3 < num)
				{
					num = num3;
					result = i;
				}
				if (i >= polygon.Count - 1)
				{
					i = 0;
				}
				else if (i == startEdgeIndex - 1)
				{
					return result;
				}
			}
			return result;
		}

		public static Vector3 ProjectPointOnLine(Vector3 point, Vector3 start, Vector3 end, bool clamped = true)
		{
			if (!clamped)
			{
				return Vector3.Project(point, end - start);
			}
			Vector3 vector = end - start;
			float sqrMagnitude = vector.sqrMagnitude;
			if (Mathf2.Approximately(sqrMagnitude, 0f))
			{
				return Vector3.zero;
			}
			float value = Vector3.Dot(point - start, vector) / sqrMagnitude;
			return start + Mathf.Clamp01(value) * vector;
		}

		public static void RoundZeroElements(ref Vector3 point)
		{
			if (point.x > -1E-06f && point.x < 1E-06f)
			{
				point.x = 0f;
			}
			if (point.y > -1E-06f && point.y < 1E-06f)
			{
				point.y = 0f;
			}
			if (point.z > -1E-06f && point.z < 1E-06f)
			{
				point.z = 0f;
			}
		}

		public static Vector2 CartesianToSperical(Vector3 point)
		{
			return new Vector2(Mathf.Atan2(point.y, point.x), Mathf.Acos(point.z));
		}

		public static Vector3 SphericalToCartesian(Vector2 point)
		{
			return new Vector3(Mathf.Cos(point.x) * Mathf.Sin(point.y), Mathf.Sin(point.x) * Mathf.Sin(point.y), Mathf.Cos(point.y));
		}

		public static float MinElement(Vector3 vector)
		{
			if (vector.x < vector.y)
			{
				if (!(vector.x < vector.z))
				{
					return vector.z;
				}
				return vector.x;
			}
			if (!(vector.y < vector.z))
			{
				return vector.z;
			}
			return vector.y;
		}

		public static float MaxElement(Vector3 vector)
		{
			if (vector.x > vector.y)
			{
				if (!(vector.x > vector.z))
				{
					return vector.z;
				}
				return vector.x;
			}
			if (!(vector.y > vector.z))
			{
				return vector.z;
			}
			return vector.y;
		}
	}
}
