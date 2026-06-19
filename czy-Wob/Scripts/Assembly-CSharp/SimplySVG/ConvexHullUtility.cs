using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	public static class ConvexHullUtility
	{
		private static float PointLocation(Vector2 A, Vector2 B, Vector2 P)
		{
			if (!((B.x - A.x) * (P.y - A.y) - (B.y - A.y) * (P.x - A.x) > 0f))
			{
				return -1f;
			}
			return 1f;
		}

		private static float Distance(Vector2 A, Vector2 B, Vector2 C)
		{
			float num = B.x - A.x;
			float num2 = B.y - A.y;
			float num3 = num * (A.y - C.y) - num2 * (A.x - C.x);
			if (num3 < 0f)
			{
				num3 = 0f - num3;
			}
			return num3;
		}

		private static void HullSet(Vector2 A, Vector2 B, List<Vector2> set, List<Vector2> hull)
		{
			int index = hull.IndexOf(B);
			if (set.Count == 0)
			{
				return;
			}
			if (set.Count == 1)
			{
				Vector2 item = set[0];
				set.Remove(item);
				hull.Insert(index, item);
				return;
			}
			float num = float.MinValue;
			int index2 = -1;
			for (int i = 0; i < set.Count; i++)
			{
				Vector2 c = set[i];
				float num2 = Distance(A, B, c);
				if (num2 > num)
				{
					num = num2;
					index2 = i;
				}
			}
			Vector2 vector = set[index2];
			set.RemoveAt(index2);
			hull.Insert(index, vector);
			List<Vector2> list = new List<Vector2>();
			for (int j = 0; j < set.Count; j++)
			{
				Vector2 vector2 = set[j];
				if (PointLocation(A, vector, vector2) == 1f)
				{
					list.Add(vector2);
				}
			}
			List<Vector2> list2 = new List<Vector2>();
			for (int k = 0; k < set.Count; k++)
			{
				Vector2 vector3 = set[k];
				if (PointLocation(vector, B, vector3) == 1f)
				{
					list2.Add(vector3);
				}
			}
			HullSet(A, vector, list, hull);
			HullSet(vector, B, list2, hull);
		}

		public static List<Vector2> QuickHull(List<Vector2> points)
		{
			List<Vector2> list = new List<Vector2>();
			if (points.Count < 3)
			{
				return points;
			}
			int index = -1;
			int index2 = -1;
			float num = float.MaxValue;
			float num2 = float.MinValue;
			for (int i = 0; i < points.Count; i++)
			{
				if (points[i].x < num)
				{
					num = points[i].x;
					index = i;
				}
				if (points[i].x > num2)
				{
					num2 = points[i].x;
					index2 = i;
				}
			}
			Vector2 vector = points[index];
			Vector2 vector2 = points[index2];
			list.Add(vector);
			list.Add(vector2);
			points.Remove(vector);
			points.Remove(vector2);
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			for (int j = 0; j < points.Count; j++)
			{
				Vector2 vector3 = points[j];
				if (PointLocation(vector, vector2, vector3) == -1f)
				{
					list2.Add(vector3);
				}
				else
				{
					list3.Add(vector3);
				}
			}
			HullSet(vector, vector2, list3, list);
			HullSet(vector2, vector, list2, list);
			return list;
		}

		public static List<Vector2> QuickHull(List<Vector3> points)
		{
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < points.Count; i++)
			{
				list.Add(new Vector2(points[i].x, points[i].y));
			}
			return QuickHull(list);
		}
	}
}
