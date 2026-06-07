using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines
{
	public static class SplineUtility
	{
		public enum MergeSide
		{
			Start = 0,
			End = 1
		}

		public static void Merge(SplineComputer baseSpline, SplineComputer addedSpline, MergeSide side, bool mergeEndpoints = false, bool destroyAddedSpline = false)
		{
			SplinePoint[] points = addedSpline.GetPoints();
			SplinePoint[] points2 = baseSpline.GetPoints();
			List<SplinePoint> list = new List<SplinePoint>();
			SplinePoint[] array;
			if (!mergeEndpoints)
			{
				array = new SplinePoint[points.Length + points2.Length];
			}
			else
			{
				array = new SplinePoint[points.Length + points2.Length - 1];
			}
			switch (side)
			{
			case MergeSide.End:
				if (side == MergeSide.Start)
				{
					for (int k = 0; k < points2.Length; k++)
					{
						list.Add(points2[k]);
					}
					for (int l = (mergeEndpoints ? 1 : 0); l < points.Length; l++)
					{
						list.Add(points[l]);
					}
				}
				else
				{
					for (int m = 0; m < points2.Length; m++)
					{
						list.Add(points2[m]);
					}
					for (int n = 0; n < points.Length - (mergeEndpoints ? 1 : 0); n++)
					{
						list.Add(points[points.Length - 1 - n]);
					}
				}
				break;
			case MergeSide.Start:
			{
				for (int num = 0; num < points.Length - (mergeEndpoints ? 1 : 0); num++)
				{
					list.Add(points[points.Length - 1 - num]);
				}
				for (int num2 = 0; num2 < points2.Length; num2++)
				{
					list.Add(points2[num2]);
				}
				break;
			}
			default:
			{
				for (int i = (mergeEndpoints ? 1 : 0); i < points.Length; i++)
				{
					list.Add(points[i]);
				}
				for (int j = 0; j < points2.Length; j++)
				{
					list.Add(points2[j]);
				}
				break;
			}
			}
			array = list.ToArray();
			double num3 = (double)(points.Length - 1) / (double)(array.Length - 1);
			double num4 = 0.0;
			double num5 = 1.0;
			if (side == MergeSide.End)
			{
				num4 = 1.0 - num3;
				num5 = 1.0;
			}
			else
			{
				num4 = 0.0;
				num5 = num3;
			}
			List<Node> list2 = new List<Node>();
			List<int> list3 = new List<int>();
			for (int num6 = 0; num6 < addedSpline.pointCount; num6++)
			{
				Node node = addedSpline.GetNode(num6);
				if (node != null)
				{
					list2.Add(node);
					list3.Add(num6);
					addedSpline.DisconnectNode(num6);
					num6--;
				}
			}
			SplineUser[] subscribers = addedSpline.GetSubscribers();
			for (int num7 = 0; num7 < subscribers.Length; num7++)
			{
				addedSpline.Unsubscribe(subscribers[num7]);
				subscribers[num7].spline = baseSpline;
				subscribers[num7].clipFrom = DMath.Lerp(num4, num5, subscribers[num7].clipFrom);
				subscribers[num7].clipTo = DMath.Lerp(num4, num5, subscribers[num7].clipTo);
			}
			baseSpline.SetPoints(array);
			if (side == MergeSide.Start)
			{
				baseSpline.ShiftNodes(0, baseSpline.pointCount - 1, addedSpline.pointCount);
				for (int num8 = 0; num8 < list2.Count; num8++)
				{
					baseSpline.ConnectNode(list2[num8], list3[num8]);
				}
			}
			else
			{
				for (int num9 = 0; num9 < list2.Count; num9++)
				{
					int num10 = list3[num9] + points2.Length;
					if (mergeEndpoints)
					{
						num10--;
					}
					baseSpline.ConnectNode(list2[num9], num10);
				}
			}
			if (destroyAddedSpline)
			{
				Object.Destroy(addedSpline.gameObject);
			}
		}
	}
}
