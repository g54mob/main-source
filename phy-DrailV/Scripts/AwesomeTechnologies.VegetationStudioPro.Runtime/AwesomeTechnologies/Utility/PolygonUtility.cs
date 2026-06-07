using System;
using System.Collections.Generic;
using System.Linq;
using AwesomeTechnologies.External.ClipperLib;
using AwesomeTechnologies.VegetationSystem.Biomes;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public class PolygonUtility
	{
		public static void AlignPointsWithTerrain(List<Vector3> pointList, bool closePolygon, LayerMask groundLayerMask)
		{
			for (int i = 0; i <= pointList.Count - 1; i++)
			{
				RaycastHit[] array = (from h in Physics.RaycastAll(new Ray(pointList[i] + new Vector3(0f, 10000f, 0f), Vector3.down), 20000f)
					orderby h.distance
					select h).ToArray();
				for (int num = 0; num <= array.Length - 1; num++)
				{
					if (array[num].collider is TerrainCollider || groundLayerMask.Contains(array[num].collider.gameObject.layer))
					{
						pointList[i] = array[num].point;
						break;
					}
				}
			}
			if (closePolygon && pointList.Count > 0)
			{
				pointList.Add(pointList[0]);
			}
		}

		public static List<Vector3> InflatePolygon(List<Vector3> pointList, double offset, bool closedPolygon)
		{
			List<Vector3> list = new List<Vector3>();
			List<IntPoint> list2 = new List<IntPoint>();
			foreach (Vector3 point in pointList)
			{
				list2.Add(new IntPoint(point.x, point.z));
			}
			ClipperOffset clipperOffset = new ClipperOffset();
			clipperOffset.AddPath(list2, JoinType.jtRound, (!closedPolygon) ? EndType.etOpenRound : EndType.etClosedPolygon);
			List<List<IntPoint>> solution = new List<List<IntPoint>>();
			clipperOffset.Execute(ref solution, offset);
			foreach (List<IntPoint> item in solution)
			{
				foreach (IntPoint item2 in item)
				{
					list.Add(new Vector3(Convert.ToInt32(item2.X), 0f, Convert.ToInt32(item2.Y)));
				}
			}
			return list;
		}

		public static List<Vector2> DouglasPeucker(List<Vector2> points, int startIndex, int lastIndex, float epsilon)
		{
			float num = 0f;
			int num2 = startIndex;
			for (int i = num2 + 1; i < lastIndex; i++)
			{
				float num3 = PointLineDistance(points[i], points[startIndex], points[lastIndex]);
				if (num3 > num)
				{
					num2 = i;
					num = num3;
				}
			}
			if (num > epsilon)
			{
				List<Vector2> list = DouglasPeucker(points, startIndex, num2, epsilon);
				List<Vector2> list2 = DouglasPeucker(points, num2, lastIndex, epsilon);
				List<Vector2> list3 = new List<Vector2>();
				for (int j = 0; j < list.Count - 1; j++)
				{
					list3.Add(list[j]);
				}
				{
					foreach (Vector2 item in list2)
					{
						list3.Add(item);
					}
					return list3;
				}
			}
			return new List<Vector2>(new Vector2[2]
			{
				points[startIndex],
				points[lastIndex]
			});
		}

		public static float PointLineDistance(Vector2 point, Vector2 start, Vector2 end)
		{
			if (start == end)
			{
				return Vector2.Distance(point, start);
			}
			float num = Mathf.Abs((end.x - start.x) * (start.y - point.y) - (start.x - point.x) * (end.y - start.y));
			float num2 = Mathf.Sqrt((end.x - start.x) * (end.x - start.x) + (end.y - start.y) * (end.y - start.y));
			return num / num2;
		}

		public static double Cross(Vector2 o, Vector2 a, Vector2 b)
		{
			return (a.x - o.x) * (b.y - o.y) - (a.y - o.y) * (b.x - o.x);
		}

		public static List<Vector2> GetConvexHull(List<Vector2> points)
		{
			if (points == null)
			{
				return null;
			}
			if (points.Count <= 1)
			{
				return points;
			}
			int count = points.Count;
			int num = 0;
			List<Vector2> list = new List<Vector2>(new Vector2[2 * count]);
			points.Sort((Vector2 a, Vector2 b) => (!a.x.Equals(b.x)) ? a.x.CompareTo(b.x) : a.y.CompareTo(b.y));
			for (int num2 = 0; num2 < count; num2++)
			{
				while (num >= 2 && Cross(list[num - 2], list[num - 1], points[num2]) <= 0.0)
				{
					num--;
				}
				list[num++] = points[num2];
			}
			int num3 = count - 2;
			int num4 = num + 1;
			while (num3 >= 0)
			{
				while (num >= num4 && Cross(list[num - 2], list[num - 1], points[num3]) <= 0.0)
				{
					num--;
				}
				list[num++] = points[num3];
				num3--;
			}
			return list.Take(num - 1).ToList();
		}

		public static List<Vector2> DouglasPeuckerReduction(List<Vector2> pointList, float tolerance)
		{
			if (pointList == null || pointList.Count < 3)
			{
				return pointList;
			}
			int num = 0;
			int num2 = pointList.Count - 1;
			List<int> pointIndexsToKeep = new List<int> { num, num2 };
			while (pointList[num].Equals(pointList[num2]))
			{
				num2--;
			}
			DouglasPeuckerReduction(pointList, num, num2, tolerance, ref pointIndexsToKeep);
			pointIndexsToKeep.Sort();
			return pointIndexsToKeep.Select((int index) => pointList[index]).ToList();
		}

		private static void DouglasPeuckerReduction(List<Vector2> points, int firstPoint, int lastPoint, float tolerance, ref List<int> pointIndexsToKeep)
		{
			float num = 0f;
			int num2 = 0;
			for (int i = firstPoint; i < lastPoint; i++)
			{
				float num3 = PerpendicularDistance(points[firstPoint], points[lastPoint], points[i]);
				if (num3 > num)
				{
					num = num3;
					num2 = i;
				}
			}
			if (num > tolerance && num2 != 0)
			{
				pointIndexsToKeep.Add(num2);
				DouglasPeuckerReduction(points, firstPoint, num2, tolerance, ref pointIndexsToKeep);
				DouglasPeuckerReduction(points, num2, lastPoint, tolerance, ref pointIndexsToKeep);
			}
		}

		public static float PerpendicularDistance(Vector2 p1, Vector2 p2, Vector2 p)
		{
			float num = Mathf.Abs(0.5f * (p1.x * p2.y + p2.x * p.y + p.x * p1.y - p2.x * p1.y - p.x * p2.y - p1.x * p.y));
			float num2 = Mathf.Sqrt(Mathf.Pow(p1.x - p2.x, 2f) + Mathf.Pow(p1.y - p2.y, 2f));
			return num / num2 * 2f;
		}
	}
}
