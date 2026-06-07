using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class BSPTree2D
	{
		private BSPTree2DNode root_;

		private PlaneEx plane_;

		public void Build(SimplePolygon polygon)
		{
			if (polygon.IsOpen())
			{
				return;
			}
			plane_ = polygon.plane;
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < polygon.segments.GetLoopCount(); i++)
			{
				List<Vertex> vertices = polygon.segments.GetLoop(i).vertices;
				for (int j = 0; j < vertices.Count; j++)
				{
					list.Add(new ExtendedEdge(vertices[j], vertices[(j + 1) % vertices.Count]));
				}
			}
			root_ = Build(list);
		}

		public void Build(List<Vector2> points, PlaneEx plane)
		{
			plane_ = plane;
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < points.Count; i++)
			{
				list.Add(new Edge(plane.FromPlaneCoord(points[i]), plane.FromPlaneCoord(points[(i + 1) % points.Count])));
			}
			root_ = Build(list);
		}

		private BSPTree2DNode Build(List<Edge> edges)
		{
			if (edges.Count == 0)
			{
				return null;
			}
			BSPTree2DNode bSPTree2DNode = new BSPTree2DNode();
			bSPTree2DNode.AddCoEdge(edges[0]);
			bSPTree2DNode.plane = plane_;
			PlaneEx planeEx = new PlaneEx(edges[0].p0, edges[0].p1, edges[0].p0 + plane_.normal);
			List<Edge> list = new List<Edge>();
			List<Edge> list2 = new List<Edge>();
			for (int i = 1; i < edges.Count; i++)
			{
				Edge outPositive;
				Edge outNegative;
				switch (planeEx.SplitEdge(edges[i], bSPTree2DNode.coedges, out outPositive, out outNegative))
				{
				case ESplitResult.Cross:
					list.Add(outPositive);
					list2.Add(outNegative);
					break;
				case ESplitResult.Positive:
					list.Add(outPositive);
					break;
				case ESplitResult.Negative:
					list2.Add(outNegative);
					break;
				case ESplitResult.Coincidence:
					if (!edges[i].IsPoint())
					{
						bSPTree2DNode.AddCoEdge(edges[i]);
					}
					break;
				}
			}
			if (list.Count > 0)
			{
				bSPTree2DNode.positive = Build(list);
			}
			if (list2.Count > 0)
			{
				bSPTree2DNode.negative = Build(list2);
			}
			return bSPTree2DNode;
		}

		public bool IsInside(Edge edge)
		{
			if (root_ == null)
			{
				return false;
			}
			return GetPartitions(edge).positives.Count == 0;
		}

		public bool IsInside(Vector3 pos)
		{
			if (root_ != null)
			{
				return root_.IsInside(pos);
			}
			return false;
		}

		public EIntersection HasIntersection(Edge edge)
		{
			if (root_ != null)
			{
				return root_.HasIntersection(edge);
			}
			return EIntersection.None;
		}

		public Partitions GetPartitions(Edge edge)
		{
			Partitions partitions = new Partitions();
			if (root_ != null)
			{
				root_.GetPartitions(edge, partitions);
			}
			return partitions;
		}

		public Partitions GetPartitions(SimplePolygon polygon)
		{
			Partitions partitions = new Partitions();
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Edge pureEdge = polygon.GetPureEdge(i);
				partitions.Join(GetPartitions(pureEdge));
			}
			return partitions;
		}
	}
}
