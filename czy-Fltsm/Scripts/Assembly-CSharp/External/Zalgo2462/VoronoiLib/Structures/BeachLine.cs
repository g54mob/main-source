using System;
using System.Collections.Generic;

namespace External.Zalgo2462.VoronoiLib.Structures
{
	internal class BeachLine
	{
		private readonly RBTree<BeachSection> beachLine;

		internal BeachLine()
		{
			beachLine = new RBTree<BeachSection>();
		}

		internal void AddBeachSection(FortuneSiteEvent siteEvent, MinHeap<FortuneEvent> eventQueue, HashSet<FortuneCircleEvent> deleted, LinkedList<VEdge> edges)
		{
			FortuneSite site = siteEvent.Site;
			double x = site.X;
			double y = site.Y;
			RBTreeNode<BeachSection> rBTreeNode = null;
			RBTreeNode<BeachSection> rBTreeNode2 = null;
			RBTreeNode<BeachSection> rBTreeNode3 = beachLine.Root;
			while (rBTreeNode3 != null && rBTreeNode == null && rBTreeNode2 == null)
			{
				double num = LeftBreakpoint(rBTreeNode3, y) - x;
				if (num > 0.0)
				{
					if (rBTreeNode3.Left == null)
					{
						rBTreeNode2 = rBTreeNode3;
					}
					else
					{
						rBTreeNode3 = rBTreeNode3.Left;
					}
					continue;
				}
				double num2 = x - RightBreakpoint(rBTreeNode3, y);
				if (num2 > 0.0)
				{
					if (rBTreeNode3.Right == null)
					{
						rBTreeNode = rBTreeNode3;
					}
					else
					{
						rBTreeNode3 = rBTreeNode3.Right;
					}
				}
				else if (num.ApproxEqual(0.0))
				{
					rBTreeNode = rBTreeNode3.Previous;
					rBTreeNode2 = rBTreeNode3;
				}
				else if (num2.ApproxEqual(0.0))
				{
					rBTreeNode = rBTreeNode3;
					rBTreeNode2 = rBTreeNode3.Next;
				}
				else
				{
					rBTreeNode = (rBTreeNode2 = rBTreeNode3);
				}
			}
			BeachSection successorData = new BeachSection(site);
			RBTreeNode<BeachSection> rBTreeNode4 = beachLine.InsertSuccessor(rBTreeNode, successorData);
			if (rBTreeNode == null && rBTreeNode2 == null)
			{
				return;
			}
			if (rBTreeNode != null && rBTreeNode == rBTreeNode2)
			{
				if (rBTreeNode.Data.CircleEvent != null)
				{
					deleted.Add(rBTreeNode.Data.CircleEvent);
					rBTreeNode.Data.CircleEvent = null;
				}
				BeachSection successorData2 = new BeachSection(rBTreeNode.Data.Site);
				rBTreeNode2 = beachLine.InsertSuccessor(rBTreeNode4, successorData2);
				double y2 = ParabolaMath.EvalParabola(rBTreeNode.Data.Site.X, rBTreeNode.Data.Site.Y, y, x);
				VPoint start = new VPoint(x, y2);
				VEdge vEdge = new VEdge(start, site, rBTreeNode.Data.Site);
				VEdge edge = (vEdge.Neighbor = new VEdge(start, rBTreeNode.Data.Site, site));
				edges.AddFirst(vEdge);
				rBTreeNode4.Data.Edge = vEdge;
				rBTreeNode2.Data.Edge = edge;
				rBTreeNode.Data.Site.Neighbors.Add(rBTreeNode4.Data.Site);
				rBTreeNode4.Data.Site.Neighbors.Add(rBTreeNode.Data.Site);
				CheckCircle(rBTreeNode, eventQueue);
				CheckCircle(rBTreeNode2, eventQueue);
			}
			else if (rBTreeNode != null && rBTreeNode2 == null)
			{
				VPoint start2 = new VPoint((rBTreeNode.Data.Site.X + site.X) / 2.0, double.MinValue);
				VEdge neighbor = new VEdge(start2, rBTreeNode.Data.Site, site);
				VEdge vEdge3 = new VEdge(start2, site, rBTreeNode.Data.Site);
				vEdge3.Neighbor = neighbor;
				edges.AddFirst(vEdge3);
				rBTreeNode.Data.Site.Neighbors.Add(rBTreeNode4.Data.Site);
				rBTreeNode4.Data.Site.Neighbors.Add(rBTreeNode.Data.Site);
				rBTreeNode4.Data.Edge = vEdge3;
			}
			else if (rBTreeNode != null && rBTreeNode != rBTreeNode2)
			{
				if (rBTreeNode.Data.CircleEvent != null)
				{
					deleted.Add(rBTreeNode.Data.CircleEvent);
					rBTreeNode.Data.CircleEvent = null;
				}
				if (rBTreeNode2.Data.CircleEvent != null)
				{
					deleted.Add(rBTreeNode2.Data.CircleEvent);
					rBTreeNode2.Data.CircleEvent = null;
				}
				FortuneSite site2 = rBTreeNode.Data.Site;
				double x2 = site2.X;
				double y3 = site2.Y;
				double num3 = site.X - x2;
				double num4 = site.Y - y3;
				FortuneSite site3 = rBTreeNode2.Data.Site;
				double num5 = site3.X - x2;
				double num6 = site3.Y - y3;
				double num7 = num3 * num6 - num4 * num5;
				double num8 = num3 * num3 + num4 * num4;
				double num9 = num5 * num5 + num6 * num6;
				VPoint vPoint = new VPoint((num6 * num8 - num4 * num9) / (2.0 * num7) + x2, (num3 * num9 - num5 * num8) / (2.0 * num7) + y3);
				rBTreeNode2.Data.Edge.End = vPoint;
				rBTreeNode4.Data.Edge = new VEdge(vPoint, site, rBTreeNode.Data.Site);
				rBTreeNode2.Data.Edge = new VEdge(vPoint, rBTreeNode2.Data.Site, site);
				edges.AddFirst(rBTreeNode4.Data.Edge);
				edges.AddFirst(rBTreeNode2.Data.Edge);
				rBTreeNode4.Data.Site.Neighbors.Add(rBTreeNode.Data.Site);
				rBTreeNode.Data.Site.Neighbors.Add(rBTreeNode4.Data.Site);
				rBTreeNode4.Data.Site.Neighbors.Add(rBTreeNode2.Data.Site);
				rBTreeNode2.Data.Site.Neighbors.Add(rBTreeNode4.Data.Site);
				CheckCircle(rBTreeNode, eventQueue);
				CheckCircle(rBTreeNode2, eventQueue);
			}
		}

		internal void RemoveBeachSection(FortuneCircleEvent circle, MinHeap<FortuneEvent> eventQueue, HashSet<FortuneCircleEvent> deleted, LinkedList<VEdge> edges)
		{
			RBTreeNode<BeachSection> toDelete = circle.ToDelete;
			double x = circle.X;
			double yCenter = circle.YCenter;
			VPoint vPoint = new VPoint(x, yCenter);
			List<RBTreeNode<BeachSection>> list = new List<RBTreeNode<BeachSection>>();
			RBTreeNode<BeachSection> previous = toDelete.Previous;
			while (previous.Data.CircleEvent != null && (x - previous.Data.CircleEvent.X).ApproxEqual(0.0) && (yCenter - previous.Data.CircleEvent.Y).ApproxEqual(0.0))
			{
				list.Add(previous);
				previous = previous.Previous;
			}
			RBTreeNode<BeachSection> next = toDelete.Next;
			while (next.Data.CircleEvent != null && (x - next.Data.CircleEvent.X).ApproxEqual(0.0) && (yCenter - next.Data.CircleEvent.Y).ApproxEqual(0.0))
			{
				list.Add(next);
				next = next.Next;
			}
			toDelete.Data.Edge.End = vPoint;
			toDelete.Next.Data.Edge.End = vPoint;
			toDelete.Data.CircleEvent = null;
			foreach (RBTreeNode<BeachSection> item in list)
			{
				item.Data.Edge.End = vPoint;
				item.Next.Data.Edge.End = vPoint;
				deleted.Add(item.Data.CircleEvent);
				item.Data.CircleEvent = null;
			}
			if (previous.Data.CircleEvent != null)
			{
				deleted.Add(previous.Data.CircleEvent);
				previous.Data.CircleEvent = null;
			}
			if (next.Data.CircleEvent != null)
			{
				deleted.Add(next.Data.CircleEvent);
				next.Data.CircleEvent = null;
			}
			VEdge vEdge = new VEdge(vPoint, next.Data.Site, previous.Data.Site);
			next.Data.Edge = vEdge;
			edges.AddFirst(vEdge);
			previous.Data.Site.Neighbors.Add(next.Data.Site);
			next.Data.Site.Neighbors.Add(previous.Data.Site);
			beachLine.RemoveNode(toDelete);
			foreach (RBTreeNode<BeachSection> item2 in list)
			{
				beachLine.RemoveNode(item2);
			}
			CheckCircle(previous, eventQueue);
			CheckCircle(next, eventQueue);
		}

		private static double LeftBreakpoint(RBTreeNode<BeachSection> node, double directrix)
		{
			RBTreeNode<BeachSection> previous = node.Previous;
			if ((node.Data.Site.Y - directrix).ApproxEqual(0.0))
			{
				return node.Data.Site.X;
			}
			if (previous == null)
			{
				return double.NegativeInfinity;
			}
			if ((previous.Data.Site.Y - directrix).ApproxEqual(0.0))
			{
				return previous.Data.Site.X;
			}
			FortuneSite site = node.Data.Site;
			FortuneSite site2 = previous.Data.Site;
			return ParabolaMath.IntersectParabolaX(site2.X, site2.Y, site.X, site.Y, directrix);
		}

		private static double RightBreakpoint(RBTreeNode<BeachSection> node, double directrix)
		{
			RBTreeNode<BeachSection> next = node.Next;
			if ((node.Data.Site.Y - directrix).ApproxEqual(0.0))
			{
				return node.Data.Site.X;
			}
			if (next == null)
			{
				return double.PositiveInfinity;
			}
			if ((next.Data.Site.Y - directrix).ApproxEqual(0.0))
			{
				return next.Data.Site.X;
			}
			FortuneSite site = node.Data.Site;
			FortuneSite site2 = next.Data.Site;
			return ParabolaMath.IntersectParabolaX(site.X, site.Y, site2.X, site2.Y, directrix);
		}

		private static void CheckCircle(RBTreeNode<BeachSection> section, MinHeap<FortuneEvent> eventQueue)
		{
			RBTreeNode<BeachSection> previous = section.Previous;
			RBTreeNode<BeachSection> next = section.Next;
			if (previous == null || next == null)
			{
				return;
			}
			FortuneSite site = previous.Data.Site;
			FortuneSite site2 = section.Data.Site;
			FortuneSite site3 = next.Data.Site;
			if (site != site3)
			{
				double x = site2.X;
				double y = site2.Y;
				double num = site.X - x;
				double num2 = site.Y - y;
				double num3 = site3.X - x;
				double num4 = site3.Y - y;
				double num5 = num * num4 - num2 * num3;
				if (!num5.ApproxGreaterThanOrEqualTo(0.0))
				{
					double num6 = num * num + num2 * num2;
					double num7 = num3 * num3 + num4 * num4;
					double num8 = (num4 * num6 - num2 * num7) / (2.0 * num5);
					double num9 = (num * num7 - num3 * num6) / (2.0 * num5);
					double num10 = num9 + y;
					FortuneCircleEvent fortuneCircleEvent = new FortuneCircleEvent(new VPoint(num8 + x, num10 + Math.Sqrt(num8 * num8 + num9 * num9)), num10, section);
					section.Data.CircleEvent = fortuneCircleEvent;
					eventQueue.Insert(fortuneCircleEvent);
				}
			}
		}
	}
}
