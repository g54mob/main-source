using System.Collections.Generic;
using External.Zalgo2462.VoronoiLib.Structures;

namespace External.Zalgo2462.VoronoiLib
{
	public static class FortunesAlgorithm
	{
		public static LinkedList<VEdge> Run(List<FortuneSite> sites, double minX, double minY, double maxX, double maxY)
		{
			MinHeap<FortuneEvent> minHeap = new MinHeap<FortuneEvent>(5 * sites.Count);
			foreach (FortuneSite site in sites)
			{
				minHeap.Insert(new FortuneSiteEvent(site));
			}
			BeachLine beachLine = new BeachLine();
			LinkedList<VEdge> linkedList = new LinkedList<VEdge>();
			HashSet<FortuneCircleEvent> hashSet = new HashSet<FortuneCircleEvent>();
			while (minHeap.Count != 0)
			{
				FortuneEvent fortuneEvent = minHeap.Pop();
				if (fortuneEvent is FortuneSiteEvent)
				{
					beachLine.AddBeachSection((FortuneSiteEvent)fortuneEvent, minHeap, hashSet, linkedList);
				}
				else if (hashSet.Contains((FortuneCircleEvent)fortuneEvent))
				{
					hashSet.Remove((FortuneCircleEvent)fortuneEvent);
				}
				else
				{
					beachLine.RemoveBeachSection((FortuneCircleEvent)fortuneEvent, minHeap, hashSet, linkedList);
				}
			}
			LinkedListNode<VEdge> linkedListNode = linkedList.First;
			while (linkedListNode != null)
			{
				VEdge value = linkedListNode.Value;
				LinkedListNode<VEdge> next = linkedListNode.Next;
				if (!ClipEdge(value, minX, minY, maxX, maxY))
				{
					linkedList.Remove(linkedListNode);
				}
				linkedListNode = next;
			}
			return linkedList;
		}

		private static bool ClipEdge(VEdge edge, double minX, double minY, double maxX, double maxY)
		{
			bool flag = false;
			if (edge.End == null)
			{
				flag = ClipRay(edge, minX, minY, maxX, maxY);
			}
			else
			{
				int num = ComputeOutCode(edge.Start.X, edge.Start.Y, minX, minY, maxX, maxY);
				int num2 = ComputeOutCode(edge.End.X, edge.End.Y, minX, minY, maxX, maxY);
				while (true)
				{
					if ((num | num2) == 0)
					{
						flag = true;
						break;
					}
					if ((num & num2) != 0)
					{
						break;
					}
					double x = -1.0;
					double y = -1.0;
					int num3 = ((num != 0) ? num : num2);
					if ((num3 & 8) != 0)
					{
						x = edge.Start.X + (edge.End.X - edge.Start.X) * (maxY - edge.Start.Y) / (edge.End.Y - edge.Start.Y);
						y = maxY;
					}
					else if ((num3 & 4) != 0)
					{
						x = edge.Start.X + (edge.End.X - edge.Start.X) * (minY - edge.Start.Y) / (edge.End.Y - edge.Start.Y);
						y = minY;
					}
					else if ((num3 & 2) != 0)
					{
						y = edge.Start.Y + (edge.End.Y - edge.Start.Y) * (maxX - edge.Start.X) / (edge.End.X - edge.Start.X);
						x = maxX;
					}
					else if ((num3 & 1) != 0)
					{
						y = edge.Start.Y + (edge.End.Y - edge.Start.Y) * (minX - edge.Start.X) / (edge.End.X - edge.Start.X);
						x = minX;
					}
					if (num3 == num)
					{
						edge.Start = new VPoint(x, y);
						num = ComputeOutCode(x, y, minX, minY, maxX, maxY);
					}
					else
					{
						edge.End = new VPoint(x, y);
						num2 = ComputeOutCode(x, y, minX, minY, maxX, maxY);
					}
				}
			}
			if (edge.Neighbor != null)
			{
				bool flag2 = ClipEdge(edge.Neighbor, minX, minY, maxX, maxY);
				if (flag && flag2)
				{
					edge.Start = edge.Neighbor.End;
				}
				if (!flag && flag2)
				{
					edge.Start = edge.Neighbor.End;
					edge.End = edge.Neighbor.Start;
					flag = true;
				}
			}
			return flag;
		}

		private static int ComputeOutCode(double x, double y, double minX, double minY, double maxX, double maxY)
		{
			int num = 0;
			if (!x.ApproxEqual(minX) && !x.ApproxEqual(maxX))
			{
				if (x < minX)
				{
					num |= 1;
				}
				else if (x > maxX)
				{
					num |= 2;
				}
			}
			if (!y.ApproxEqual(minY) && !x.ApproxEqual(maxY))
			{
				if (y < minY)
				{
					num |= 4;
				}
				else if (y > maxY)
				{
					num |= 8;
				}
			}
			return num;
		}

		private static bool ClipRay(VEdge edge, double minX, double minY, double maxX, double maxY)
		{
			VPoint start = edge.Start;
			if (edge.SlopeRise.ApproxEqual(0.0))
			{
				if (!Within(start.Y, minY, maxY))
				{
					return false;
				}
				if (edge.SlopeRun > 0.0 && start.X > maxX)
				{
					return false;
				}
				if (edge.SlopeRun < 0.0 && start.X < minX)
				{
					return false;
				}
				if (Within(start.X, minX, maxX))
				{
					if (edge.SlopeRun > 0.0)
					{
						edge.End = new VPoint(maxX, start.Y);
					}
					else
					{
						edge.End = new VPoint(minX, start.Y);
					}
				}
				else if (edge.SlopeRun > 0.0)
				{
					edge.Start = new VPoint(minX, start.Y);
					edge.End = new VPoint(maxX, start.Y);
				}
				else
				{
					edge.Start = new VPoint(maxX, start.Y);
					edge.End = new VPoint(minX, start.Y);
				}
				return true;
			}
			if (edge.SlopeRun.ApproxEqual(0.0))
			{
				if (start.X < minX || start.X > maxX)
				{
					return false;
				}
				if (edge.SlopeRise > 0.0 && start.Y > maxY)
				{
					return false;
				}
				if (edge.SlopeRise < 0.0 && start.Y < minY)
				{
					return false;
				}
				if (Within(start.Y, minY, maxY))
				{
					if (edge.SlopeRise > 0.0)
					{
						edge.End = new VPoint(start.X, maxY);
					}
					else
					{
						edge.End = new VPoint(start.X, minY);
					}
				}
				else if (edge.SlopeRise > 0.0)
				{
					edge.Start = new VPoint(start.X, minY);
					edge.End = new VPoint(start.X, maxY);
				}
				else
				{
					edge.Start = new VPoint(start.X, maxY);
					edge.End = new VPoint(start.X, minY);
				}
				return true;
			}
			VPoint vPoint = new VPoint(CalcX(edge.Slope.Value, maxY, edge.Intercept.Value), maxY);
			VPoint vPoint2 = new VPoint(CalcX(edge.Slope.Value, minY, edge.Intercept.Value), minY);
			VPoint vPoint3 = new VPoint(minX, CalcY(edge.Slope.Value, minX, edge.Intercept.Value));
			VPoint vPoint4 = new VPoint(maxX, CalcY(edge.Slope.Value, maxX, edge.Intercept.Value));
			List<VPoint> list = new List<VPoint>();
			if (Within(vPoint.X, minX, maxX))
			{
				list.Add(vPoint);
			}
			if (Within(vPoint2.X, minX, maxX))
			{
				list.Add(vPoint2);
			}
			if (Within(vPoint3.Y, minY, maxY))
			{
				list.Add(vPoint3);
			}
			if (Within(vPoint4.Y, minY, maxY))
			{
				list.Add(vPoint4);
			}
			for (int num = list.Count - 1; num > -1; num--)
			{
				VPoint vPoint5 = list[num];
				double num2 = vPoint5.X - start.X;
				double num3 = vPoint5.Y - start.Y;
				if (edge.SlopeRun * num2 + edge.SlopeRise * num3 < 0.0)
				{
					list.RemoveAt(num);
				}
			}
			if (list.Count == 2)
			{
				double num4 = list[0].X - start.X;
				double num5 = list[0].Y - start.Y;
				double num6 = list[1].X - start.X;
				double num7 = list[1].Y - start.Y;
				if (num4 * num4 + num5 * num5 > num6 * num6 + num7 * num7)
				{
					edge.Start = list[1];
					edge.End = list[0];
				}
				else
				{
					edge.Start = list[0];
					edge.End = list[1];
				}
			}
			if (list.Count == 1)
			{
				edge.End = list[0];
			}
			return edge.End != null;
		}

		private static bool Within(double x, double a, double b)
		{
			if (x.ApproxGreaterThanOrEqualTo(a))
			{
				return x.ApproxLessThanOrEqualTo(b);
			}
			return false;
		}

		private static double CalcY(double m, double x, double b)
		{
			return m * x + b;
		}

		private static double CalcX(double m, double y, double b)
		{
			return (y - b) / m;
		}
	}
}
