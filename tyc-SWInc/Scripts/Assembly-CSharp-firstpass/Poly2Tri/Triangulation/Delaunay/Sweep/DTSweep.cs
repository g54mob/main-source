using System;
using System.Collections.Generic;
using Poly2Tri.Triangulation.Util;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Delaunay.Sweep
{
	public static class DTSweep
	{
		private const double PI_DIV2 = Math.PI / 2.0;

		private const double PI_3_DIV4 = Math.PI * 3.0 / 4.0;

		public static void Triangulate(DTSweepContext tcx)
		{
			tcx.CreateAdvancingFront();
			Sweep(tcx);
			FixupConstrainedEdges(tcx);
			if (tcx.TriangulationMode == TriangulationMode.Polygon)
			{
				FinalizationPolygon(tcx);
				return;
			}
			FinalizationConvexHull(tcx);
			if (tcx.TriangulationMode == TriangulationMode.Constrained)
			{
				tcx.FinalizeTriangulation();
			}
			else
			{
				tcx.FinalizeTriangulation();
			}
		}

		private static void Sweep(DTSweepContext tcx)
		{
			List<TriangulationPoint> points = tcx.Points;
			for (int i = 1; i < points.Count; i++)
			{
				TriangulationPoint triangulationPoint = points[i];
				AdvancingFrontNode advancingFrontNode = PointEvent(tcx, triangulationPoint);
				if (advancingFrontNode == null || !triangulationPoint.HasEdges)
				{
					continue;
				}
				foreach (DTSweepConstraint edge in triangulationPoint.Edges)
				{
					if (tcx.IsDebugEnabled)
					{
						tcx.DebugContext.ActiveConstraint = edge;
					}
					EdgeEvent(tcx, edge, advancingFrontNode);
				}
			}
		}

		private static void FixupConstrainedEdges(TriangulationContext tcx)
		{
			foreach (DelaunayTriangle triangle in tcx.Triangles)
			{
				for (int i = 0; i < 3; i++)
				{
					DTSweepConstraint edge;
					if (!triangle.GetConstrainedEdgeCCW(triangle.Points[i]) && triangle.GetEdgeCCW(triangle.Points[i], out edge))
					{
						triangle.MarkConstrainedEdge((i + 2) % 3);
					}
				}
			}
		}

		private static void FinalizationConvexHull(DTSweepContext tcx)
		{
			AdvancingFrontNode next = tcx.Front.Head.Next;
			AdvancingFrontNode next2 = next.Next;
			TurnAdvancingFrontConvex(tcx, next, next2);
			next = tcx.Front.Tail.Prev;
			DelaunayTriangle delaunayTriangle;
			if (next.Triangle.Contains(next.Next.Point) && next.Triangle.Contains(next.Prev.Point))
			{
				delaunayTriangle = next.Triangle.NeighborAcrossFrom(next.Point);
				RotateTrianglePair(next.Triangle, next.Point, delaunayTriangle, delaunayTriangle.OppositePoint(next.Triangle, next.Point));
				tcx.MapTriangleToNodes(next.Triangle);
				tcx.MapTriangleToNodes(delaunayTriangle);
			}
			next = tcx.Front.Head.Next;
			if (next.Triangle.Contains(next.Prev.Point) && next.Triangle.Contains(next.Next.Point))
			{
				delaunayTriangle = next.Triangle.NeighborAcrossFrom(next.Point);
				RotateTrianglePair(next.Triangle, next.Point, delaunayTriangle, delaunayTriangle.OppositePoint(next.Triangle, next.Point));
				tcx.MapTriangleToNodes(next.Triangle);
				tcx.MapTriangleToNodes(delaunayTriangle);
			}
			TriangulationPoint point = tcx.Front.Head.Point;
			next2 = tcx.Front.Tail.Prev;
			delaunayTriangle = next2.Triangle;
			TriangulationPoint triangulationPoint = next2.Point;
			next2.Triangle = null;
			while (true)
			{
				tcx.RemoveFromList(delaunayTriangle);
				triangulationPoint = delaunayTriangle.PointCCWFrom(triangulationPoint);
				if (triangulationPoint.Equals(point))
				{
					break;
				}
				DelaunayTriangle delaunayTriangle2 = delaunayTriangle.NeighborCCWFrom(triangulationPoint);
				delaunayTriangle.Clear();
				delaunayTriangle = delaunayTriangle2;
			}
			point = tcx.Front.Head.Next.Point;
			triangulationPoint = delaunayTriangle.PointCWFrom(tcx.Front.Head.Point);
			DelaunayTriangle delaunayTriangle3 = delaunayTriangle.NeighborCWFrom(tcx.Front.Head.Point);
			delaunayTriangle.Clear();
			delaunayTriangle = delaunayTriangle3;
			while (triangulationPoint.Equals(point))
			{
				tcx.RemoveFromList(delaunayTriangle);
				triangulationPoint = delaunayTriangle.PointCCWFrom(triangulationPoint);
				DelaunayTriangle delaunayTriangle4 = delaunayTriangle.NeighborCCWFrom(triangulationPoint);
				delaunayTriangle.Clear();
				delaunayTriangle = delaunayTriangle4;
			}
			tcx.Front.Head = tcx.Front.Head.Next;
			tcx.Front.Head.Prev = null;
			tcx.Front.Tail = tcx.Front.Tail.Prev;
			tcx.Front.Tail.Next = null;
		}

		private static void TurnAdvancingFrontConvex(DTSweepContext tcx, AdvancingFrontNode b, AdvancingFrontNode c)
		{
			AdvancingFrontNode advancingFrontNode = b;
			while (c != tcx.Front.Tail)
			{
				if (tcx.IsDebugEnabled)
				{
					tcx.DebugContext.ActiveNode = c;
				}
				if (TriangulationUtil.Orient2d(b.Point, c.Point, c.Next.Point) == Orientation.AntiClockwise)
				{
					Fill(tcx, c);
					c = c.Next;
				}
				else if (b != advancingFrontNode && TriangulationUtil.Orient2d(b.Prev.Point, b.Point, c.Point) == Orientation.AntiClockwise)
				{
					Fill(tcx, b);
					b = b.Prev;
				}
				else
				{
					b = c;
					c = c.Next;
				}
			}
		}

		private static void FinalizationPolygon(DTSweepContext tcx)
		{
			DelaunayTriangle delaunayTriangle = tcx.Front.Head.Next.Triangle;
			TriangulationPoint point = tcx.Front.Head.Next.Point;
			while (!delaunayTriangle.GetConstrainedEdgeCW(point))
			{
				DelaunayTriangle delaunayTriangle2 = delaunayTriangle.NeighborCCWFrom(point);
				if (delaunayTriangle2 == null)
				{
					break;
				}
				delaunayTriangle = delaunayTriangle2;
			}
			tcx.MeshClean(delaunayTriangle);
		}

		private static void FinalizationConstraints(DTSweepContext tcx)
		{
			DelaunayTriangle delaunayTriangle = tcx.Front.Head.Triangle;
			TriangulationPoint point = tcx.Front.Head.Point;
			while (!delaunayTriangle.GetConstrainedEdgeCW(point))
			{
				DelaunayTriangle delaunayTriangle2 = delaunayTriangle.NeighborCCWFrom(point);
				if (delaunayTriangle2 == null)
				{
					break;
				}
				delaunayTriangle = delaunayTriangle2;
			}
			tcx.MeshClean(delaunayTriangle);
		}

		private static AdvancingFrontNode PointEvent(DTSweepContext tcx, TriangulationPoint point)
		{
			AdvancingFrontNode advancingFrontNode = tcx.LocateNode(point);
			if (tcx.IsDebugEnabled)
			{
				tcx.DebugContext.ActiveNode = advancingFrontNode;
			}
			if (advancingFrontNode == null || point == null)
			{
				return null;
			}
			AdvancingFrontNode advancingFrontNode2 = NewFrontTriangle(tcx, point, advancingFrontNode);
			if (point.X <= advancingFrontNode.Point.X + 1E-12)
			{
				Fill(tcx, advancingFrontNode);
			}
			FillAdvancingFront(tcx, advancingFrontNode2);
			return advancingFrontNode2;
		}

		private static AdvancingFrontNode NewFrontTriangle(DTSweepContext tcx, TriangulationPoint point, AdvancingFrontNode node)
		{
			DelaunayTriangle delaunayTriangle = new DelaunayTriangle(point, node.Point, node.Next.Point);
			delaunayTriangle.MarkNeighbor(node.Triangle);
			tcx.Triangles.Add(delaunayTriangle);
			AdvancingFrontNode advancingFrontNode = new AdvancingFrontNode(point)
			{
				Next = node.Next,
				Prev = node
			};
			node.Next.Prev = advancingFrontNode;
			node.Next = advancingFrontNode;
			if (tcx.IsDebugEnabled)
			{
				tcx.DebugContext.ActiveNode = advancingFrontNode;
			}
			if (!Legalize(tcx, delaunayTriangle))
			{
				tcx.MapTriangleToNodes(delaunayTriangle);
			}
			return advancingFrontNode;
		}

		private static void EdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
			tcx.EdgeEvent.ConstrainedEdge = edge;
			tcx.EdgeEvent.Right = edge.P.X > edge.Q.X;
			if (tcx.IsDebugEnabled)
			{
				tcx.DebugContext.PrimaryTriangle = node.Triangle;
			}
			if (!IsEdgeSideOfTriangle(node.Triangle, edge.P, edge.Q))
			{
				FillEdgeEvent(tcx, edge, node);
				EdgeEvent(tcx, edge.P, edge.Q, node.Triangle, edge.Q);
			}
		}

		private static void FillEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node)
		{
			if (tcx.EdgeEvent.Right)
			{
				FillRightAboveEdgeEvent(tcx, edge, node);
			}
			else
			{
				FillLeftAboveEdgeEvent(tcx, edge, node);
			}
		}

		private static void FillRightConcaveEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node)
		{
			Fill(tcx, node.Next);
			if (node.Next.Point.Equals(edge.P) && TriangulationUtil.Orient2d(edge.Q, node.Next.Point, edge.P) == Orientation.AntiClockwise && TriangulationUtil.Orient2d(node.Point, node.Next.Point, node.Next.Next.Point) == Orientation.AntiClockwise)
			{
				FillRightConcaveEdgeEvent(tcx, edge, node);
			}
		}

		private static void FillRightConvexEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node)
		{
			if (TriangulationUtil.Orient2d(node.Next.Point, node.Next.Next.Point, node.Next.Next.Next.Point) == Orientation.AntiClockwise)
			{
				FillRightConcaveEdgeEvent(tcx, edge, node.Next);
			}
			else if (TriangulationUtil.Orient2d(edge.Q, node.Next.Next.Point, edge.P) == Orientation.AntiClockwise)
			{
				FillRightConvexEdgeEvent(tcx, edge, node.Next);
			}
		}

		private static void FillRightBelowEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node)
		{
			if (tcx.IsDebugEnabled)
			{
				tcx.DebugContext.ActiveNode = node;
			}
			if (node.Point.X < edge.P.X)
			{
				if (TriangulationUtil.Orient2d(node.Point, node.Next.Point, node.Next.Next.Point) == Orientation.AntiClockwise)
				{
					FillRightConcaveEdgeEvent(tcx, edge, node);
					return;
				}
				FillRightConvexEdgeEvent(tcx, edge, node);
				FillRightBelowEdgeEvent(tcx, edge, node);
			}
		}

		private static void FillRightAboveEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node)
		{
			while (node.Next.Point.X < edge.P.X)
			{
				if (tcx.IsDebugEnabled)
				{
					tcx.DebugContext.ActiveNode = node;
				}
				if (TriangulationUtil.Orient2d(edge.Q, node.Next.Point, edge.P) == Orientation.AntiClockwise)
				{
					FillRightBelowEdgeEvent(tcx, edge, node);
				}
				else
				{
					node = node.Next;
				}
			}
		}

		private static void FillLeftConvexEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node)
		{
			if (TriangulationUtil.Orient2d(node.Prev.Point, node.Prev.Prev.Point, node.Prev.Prev.Prev.Point) == Orientation.Clockwise)
			{
				FillLeftConcaveEdgeEvent(tcx, edge, node.Prev);
			}
			else if (TriangulationUtil.Orient2d(edge.Q, node.Prev.Prev.Point, edge.P) == Orientation.Clockwise)
			{
				FillLeftConvexEdgeEvent(tcx, edge, node.Prev);
			}
		}

		private static void FillLeftConcaveEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node)
		{
			Fill(tcx, node.Prev);
			if (node.Prev.Point.Equals(edge.P) && TriangulationUtil.Orient2d(edge.Q, node.Prev.Point, edge.P) == Orientation.Clockwise && TriangulationUtil.Orient2d(node.Point, node.Prev.Point, node.Prev.Prev.Point) == Orientation.Clockwise)
			{
				FillLeftConcaveEdgeEvent(tcx, edge, node);
			}
		}

		private static void FillLeftBelowEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node)
		{
			if (tcx.IsDebugEnabled)
			{
				tcx.DebugContext.ActiveNode = node;
			}
			if (node.Point.X > edge.P.X)
			{
				if (TriangulationUtil.Orient2d(node.Point, node.Prev.Point, node.Prev.Prev.Point) == Orientation.Clockwise)
				{
					FillLeftConcaveEdgeEvent(tcx, edge, node);
					return;
				}
				FillLeftConvexEdgeEvent(tcx, edge, node);
				FillLeftBelowEdgeEvent(tcx, edge, node);
			}
		}

		private static void FillLeftAboveEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node)
		{
			while (node.Prev.Point.X > edge.P.X)
			{
				if (tcx.IsDebugEnabled)
				{
					tcx.DebugContext.ActiveNode = node;
				}
				if (TriangulationUtil.Orient2d(edge.Q, node.Prev.Point, edge.P) == Orientation.Clockwise)
				{
					FillLeftBelowEdgeEvent(tcx, edge, node);
				}
				else
				{
					node = node.Prev;
				}
			}
		}

		private static bool IsEdgeSideOfTriangle(DelaunayTriangle triangle, TriangulationPoint ep, TriangulationPoint eq)
		{
			int num = triangle.EdgeIndex(ep, eq);
			if (num == -1)
			{
				return false;
			}
			triangle.MarkConstrainedEdge(num);
			triangle = triangle.Neighbors[num];
			if (triangle != null)
			{
				triangle.MarkConstrainedEdge(ep, eq);
			}
			return true;
		}

		private static void EdgeEvent(DTSweepContext tcx, TriangulationPoint ep, TriangulationPoint eq, DelaunayTriangle triangle, TriangulationPoint point)
		{
			if (tcx.IsDebugEnabled)
			{
				tcx.DebugContext.PrimaryTriangle = triangle;
			}
			if (IsEdgeSideOfTriangle(triangle, ep, eq))
			{
				return;
			}
			TriangulationPoint triangulationPoint = triangle.PointCCWFrom(point);
			Orientation orientation = TriangulationUtil.Orient2d(eq, triangulationPoint, ep);
			if (orientation == Orientation.Collinear)
			{
				if (triangle.Contains(eq) && triangle.Contains(triangulationPoint))
				{
					triangle.MarkConstrainedEdge(eq, triangulationPoint);
					tcx.EdgeEvent.ConstrainedEdge.Q = triangulationPoint;
					triangle = triangle.NeighborAcrossFrom(point);
					EdgeEvent(tcx, ep, triangulationPoint, triangle, triangulationPoint);
					if (tcx.IsDebugEnabled)
					{
						Console.WriteLine("EdgeEvent - Point on constrained edge");
					}
					return;
				}
				throw new PointOnEdgeException("EdgeEvent - Point on constrained edge not supported yet", ep, eq, triangulationPoint);
			}
			TriangulationPoint triangulationPoint2 = triangle.PointCWFrom(point);
			Orientation orientation2 = TriangulationUtil.Orient2d(eq, triangulationPoint2, ep);
			if (orientation2 == Orientation.Collinear)
			{
				if (!triangle.Contains(eq) || !triangle.Contains(triangulationPoint2))
				{
					throw new PointOnEdgeException("EdgeEvent - Point on constrained edge not supported yet", ep, eq, triangulationPoint2);
				}
				triangle.MarkConstrainedEdge(eq, triangulationPoint2);
				tcx.EdgeEvent.ConstrainedEdge.Q = triangulationPoint2;
				triangle = triangle.NeighborAcrossFrom(point);
				EdgeEvent(tcx, ep, triangulationPoint2, triangle, triangulationPoint2);
				if (tcx.IsDebugEnabled)
				{
					Console.WriteLine("EdgeEvent - Point on constrained edge");
				}
			}
			else if (orientation == orientation2)
			{
				triangle = ((orientation == Orientation.Clockwise) ? triangle.NeighborCCWFrom(point) : triangle.NeighborCWFrom(point));
				EdgeEvent(tcx, ep, eq, triangle, point);
			}
			else
			{
				FlipEdgeEvent(tcx, ep, eq, triangle, point);
			}
		}

		private static void FlipEdgeEvent(DTSweepContext tcx, TriangulationPoint ep, TriangulationPoint eq, DelaunayTriangle t, TriangulationPoint p)
		{
			DelaunayTriangle delaunayTriangle = t.NeighborAcrossFrom(p);
			TriangulationPoint triangulationPoint = delaunayTriangle.OppositePoint(t, p);
			if (delaunayTriangle == null)
			{
				throw new InvalidOperationException("[BUG:FIXME] FLIP failed due to missing triangle");
			}
			if (tcx.IsDebugEnabled)
			{
				tcx.DebugContext.PrimaryTriangle = t;
				tcx.DebugContext.SecondaryTriangle = delaunayTriangle;
			}
			TriangulationPoint newP;
			if (TriangulationUtil.InScanArea(p, t.PointCCWFrom(p), t.PointCWFrom(p), triangulationPoint))
			{
				RotateTrianglePair(t, p, delaunayTriangle, triangulationPoint);
				tcx.MapTriangleToNodes(t);
				tcx.MapTriangleToNodes(delaunayTriangle);
				if (p.Equals(eq) && triangulationPoint.Equals(ep))
				{
					if (eq.Equals(tcx.EdgeEvent.ConstrainedEdge.Q) && ep.Equals(tcx.EdgeEvent.ConstrainedEdge.P))
					{
						if (tcx.IsDebugEnabled)
						{
							Console.WriteLine("[FLIP] - constrained edge done");
						}
						t.MarkConstrainedEdge(ep, eq);
						delaunayTriangle.MarkConstrainedEdge(ep, eq);
						Legalize(tcx, t);
						Legalize(tcx, delaunayTriangle);
					}
					else if (tcx.IsDebugEnabled)
					{
						Console.WriteLine("[FLIP] - subedge done");
					}
				}
				else
				{
					if (tcx.IsDebugEnabled)
					{
						Console.WriteLine("[FLIP] - flipping and continuing with triangle still crossing edge");
					}
					Orientation o = TriangulationUtil.Orient2d(eq, triangulationPoint, ep);
					t = NextFlipTriangle(tcx, o, t, delaunayTriangle, p, triangulationPoint);
					FlipEdgeEvent(tcx, ep, eq, t, p);
				}
			}
			else if (NextFlipPoint(ep, eq, delaunayTriangle, triangulationPoint, out newP))
			{
				FlipScanEdgeEvent(tcx, ep, eq, t, delaunayTriangle, newP);
				EdgeEvent(tcx, ep, eq, t, p);
			}
		}

		private static bool NextFlipPoint(Point2D ep, Point2D eq, DelaunayTriangle ot, TriangulationPoint op, out TriangulationPoint newP)
		{
			newP = null;
			switch (TriangulationUtil.Orient2d(eq, op, ep))
			{
			case Orientation.Clockwise:
				newP = ot.PointCCWFrom(op);
				return true;
			case Orientation.AntiClockwise:
				newP = ot.PointCWFrom(op);
				return true;
			case Orientation.Collinear:
				return false;
			default:
				throw new NotImplementedException("Orientation not handled");
			}
		}

		private static DelaunayTriangle NextFlipTriangle(DTSweepContext tcx, Orientation o, DelaunayTriangle t, DelaunayTriangle ot, TriangulationPoint p, TriangulationPoint op)
		{
			int index;
			if (o == Orientation.AntiClockwise)
			{
				index = ot.EdgeIndex(p, op);
				ot.EdgeIsDelaunay[index] = true;
				Legalize(tcx, ot);
				ot.EdgeIsDelaunay.Clear();
				return t;
			}
			index = t.EdgeIndex(p, op);
			t.EdgeIsDelaunay[index] = true;
			Legalize(tcx, t);
			t.EdgeIsDelaunay.Clear();
			return ot;
		}

		private static void FlipScanEdgeEvent(DTSweepContext tcx, Point2D ep, TriangulationPoint eq, DelaunayTriangle flipTriangle, DelaunayTriangle t, TriangulationPoint p)
		{
			DelaunayTriangle delaunayTriangle = t.NeighborAcrossFrom(p);
			TriangulationPoint triangulationPoint = delaunayTriangle.OppositePoint(t, p);
			if (delaunayTriangle == null)
			{
				throw new Exception("[BUG:FIXME] FLIP failed due to missing triangle");
			}
			if (tcx.IsDebugEnabled)
			{
				Console.WriteLine("[FLIP:SCAN] - scan next point");
				tcx.DebugContext.PrimaryTriangle = t;
				tcx.DebugContext.SecondaryTriangle = delaunayTriangle;
			}
			TriangulationPoint newP;
			if (TriangulationUtil.InScanArea(eq, flipTriangle.PointCCWFrom(eq), flipTriangle.PointCWFrom(eq), triangulationPoint))
			{
				FlipEdgeEvent(tcx, eq, triangulationPoint, delaunayTriangle, triangulationPoint);
			}
			else if (NextFlipPoint(ep, eq, delaunayTriangle, triangulationPoint, out newP))
			{
				FlipScanEdgeEvent(tcx, ep, eq, flipTriangle, delaunayTriangle, newP);
			}
		}

		private static void FillAdvancingFront(DTSweepContext tcx, AdvancingFrontNode n)
		{
			AdvancingFrontNode next = n.Next;
			while (next.HasNext)
			{
				double num = HoleAngle(next);
				if (num > Math.PI / 2.0 || num < -Math.PI / 2.0)
				{
					break;
				}
				Fill(tcx, next);
				next = next.Next;
			}
			next = n.Prev;
			while (next.HasPrev)
			{
				double num = HoleAngle(next);
				if (num > Math.PI / 2.0 || num < -Math.PI / 2.0)
				{
					break;
				}
				Fill(tcx, next);
				next = next.Prev;
			}
			if (n.HasNext && n.Next.HasNext)
			{
				double num = BasinAngle(n);
				if (num < Math.PI * 3.0 / 4.0)
				{
					FillBasin(tcx, n);
				}
			}
		}

		private static void FillBasin(DTSweepContext tcx, AdvancingFrontNode node)
		{
			tcx.Basin.LeftNode = ((TriangulationUtil.Orient2d(node.Point, node.Next.Point, node.Next.Next.Point) == Orientation.AntiClockwise) ? node : node.Next);
			tcx.Basin.BottomNode = tcx.Basin.LeftNode;
			while (tcx.Basin.BottomNode.HasNext && tcx.Basin.BottomNode.Point.Y >= tcx.Basin.BottomNode.Next.Point.Y)
			{
				tcx.Basin.BottomNode = tcx.Basin.BottomNode.Next;
			}
			if (tcx.Basin.BottomNode != tcx.Basin.LeftNode)
			{
				tcx.Basin.RightNode = tcx.Basin.BottomNode;
				while (tcx.Basin.RightNode.HasNext && tcx.Basin.RightNode.Point.Y < tcx.Basin.RightNode.Next.Point.Y)
				{
					tcx.Basin.RightNode = tcx.Basin.RightNode.Next;
				}
				if (tcx.Basin.RightNode != tcx.Basin.BottomNode)
				{
					tcx.Basin.Width = tcx.Basin.RightNode.Point.X - tcx.Basin.LeftNode.Point.X;
					tcx.Basin.LeftHighest = tcx.Basin.LeftNode.Point.Y > tcx.Basin.RightNode.Point.Y;
					FillBasinReq(tcx, tcx.Basin.BottomNode);
				}
			}
		}

		private static void FillBasinReq(DTSweepContext tcx, AdvancingFrontNode node)
		{
			if (IsShallow(tcx, node))
			{
				return;
			}
			Fill(tcx, node);
			if (node.Prev == tcx.Basin.LeftNode && node.Next == tcx.Basin.RightNode)
			{
				return;
			}
			if (node.Prev == tcx.Basin.LeftNode)
			{
				if (TriangulationUtil.Orient2d(node.Point, node.Next.Point, node.Next.Next.Point) == Orientation.Clockwise)
				{
					return;
				}
				node = node.Next;
			}
			else if (node.Next == tcx.Basin.RightNode)
			{
				if (TriangulationUtil.Orient2d(node.Point, node.Prev.Point, node.Prev.Prev.Point) == Orientation.AntiClockwise)
				{
					return;
				}
				node = node.Prev;
			}
			else
			{
				node = ((node.Prev.Point.Y < node.Next.Point.Y) ? node.Prev : node.Next);
			}
			FillBasinReq(tcx, node);
		}

		private static bool IsShallow(DTSweepContext tcx, AdvancingFrontNode node)
		{
			double num = ((!tcx.Basin.LeftHighest) ? (tcx.Basin.RightNode.Point.Y - node.Point.Y) : (tcx.Basin.LeftNode.Point.Y - node.Point.Y));
			if (tcx.Basin.Width > num)
			{
				return true;
			}
			return false;
		}

		private static double HoleAngle(AdvancingFrontNode node)
		{
			double x = node.Point.X;
			double y = node.Point.Y;
			double num = node.Next.Point.X - x;
			double num2 = node.Next.Point.Y - y;
			double num3 = node.Prev.Point.X - x;
			double num4 = node.Prev.Point.Y - y;
			return Math.Atan2(num * num4 - num2 * num3, num * num3 + num2 * num4);
		}

		private static double BasinAngle(AdvancingFrontNode node)
		{
			double x = node.Point.X - node.Next.Next.Point.X;
			return Math.Atan2(node.Point.Y - node.Next.Next.Point.Y, x);
		}

		private static void Fill(DTSweepContext tcx, AdvancingFrontNode node)
		{
			DelaunayTriangle delaunayTriangle = new DelaunayTriangle(node.Prev.Point, node.Point, node.Next.Point);
			delaunayTriangle.MarkNeighbor(node.Prev.Triangle);
			delaunayTriangle.MarkNeighbor(node.Triangle);
			tcx.Triangles.Add(delaunayTriangle);
			node.Prev.Next = node.Next;
			node.Next.Prev = node.Prev;
			if (!Legalize(tcx, delaunayTriangle))
			{
				tcx.MapTriangleToNodes(delaunayTriangle);
			}
		}

		private static bool Legalize(DTSweepContext tcx, DelaunayTriangle t)
		{
			for (int i = 0; i < 3; i++)
			{
				if (t.EdgeIsDelaunay[i])
				{
					continue;
				}
				DelaunayTriangle delaunayTriangle = t.Neighbors[i];
				if (delaunayTriangle == null)
				{
					continue;
				}
				TriangulationPoint triangulationPoint = t.Points[i];
				TriangulationPoint triangulationPoint2 = delaunayTriangle.OppositePoint(t, triangulationPoint);
				int index = delaunayTriangle.IndexOf(triangulationPoint2);
				if (delaunayTriangle.EdgeIsConstrained[index] || delaunayTriangle.EdgeIsDelaunay[index])
				{
					t.SetConstrainedEdgeAcross(triangulationPoint, delaunayTriangle.EdgeIsConstrained[index]);
				}
				else if (TriangulationUtil.SmartIncircle(triangulationPoint, t.PointCCWFrom(triangulationPoint), t.PointCWFrom(triangulationPoint), triangulationPoint2))
				{
					t.EdgeIsDelaunay[i] = true;
					delaunayTriangle.EdgeIsDelaunay[index] = true;
					RotateTrianglePair(t, triangulationPoint, delaunayTriangle, triangulationPoint2);
					if (!Legalize(tcx, t))
					{
						tcx.MapTriangleToNodes(t);
					}
					if (!Legalize(tcx, delaunayTriangle))
					{
						tcx.MapTriangleToNodes(delaunayTriangle);
					}
					t.EdgeIsDelaunay[i] = false;
					delaunayTriangle.EdgeIsDelaunay[index] = false;
					return true;
				}
			}
			return false;
		}

		private static void RotateTrianglePair(DelaunayTriangle t, TriangulationPoint p, DelaunayTriangle ot, TriangulationPoint op)
		{
			DelaunayTriangle delaunayTriangle = t.NeighborCCWFrom(p);
			DelaunayTriangle delaunayTriangle2 = t.NeighborCWFrom(p);
			DelaunayTriangle delaunayTriangle3 = ot.NeighborCCWFrom(op);
			DelaunayTriangle delaunayTriangle4 = ot.NeighborCWFrom(op);
			bool constrainedEdgeCCW = t.GetConstrainedEdgeCCW(p);
			bool constrainedEdgeCW = t.GetConstrainedEdgeCW(p);
			bool constrainedEdgeCCW2 = ot.GetConstrainedEdgeCCW(op);
			bool constrainedEdgeCW2 = ot.GetConstrainedEdgeCW(op);
			bool delaunayEdgeCCW = t.GetDelaunayEdgeCCW(p);
			bool delaunayEdgeCW = t.GetDelaunayEdgeCW(p);
			bool delaunayEdgeCCW2 = ot.GetDelaunayEdgeCCW(op);
			bool delaunayEdgeCW2 = ot.GetDelaunayEdgeCW(op);
			t.Legalize(p, op);
			ot.Legalize(op, p);
			ot.SetDelaunayEdgeCCW(p, delaunayEdgeCCW);
			t.SetDelaunayEdgeCW(p, delaunayEdgeCW);
			t.SetDelaunayEdgeCCW(op, delaunayEdgeCCW2);
			ot.SetDelaunayEdgeCW(op, delaunayEdgeCW2);
			ot.SetConstrainedEdgeCCW(p, constrainedEdgeCCW);
			t.SetConstrainedEdgeCW(p, constrainedEdgeCW);
			t.SetConstrainedEdgeCCW(op, constrainedEdgeCCW2);
			ot.SetConstrainedEdgeCW(op, constrainedEdgeCW2);
			t.Neighbors.Clear();
			ot.Neighbors.Clear();
			if (delaunayTriangle != null)
			{
				ot.MarkNeighbor(delaunayTriangle);
			}
			if (delaunayTriangle2 != null)
			{
				t.MarkNeighbor(delaunayTriangle2);
			}
			if (delaunayTriangle3 != null)
			{
				t.MarkNeighbor(delaunayTriangle3);
			}
			if (delaunayTriangle4 != null)
			{
				ot.MarkNeighbor(delaunayTriangle4);
			}
			t.MarkNeighbor(ot);
		}
	}
}
