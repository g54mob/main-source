namespace Poly2Tri.Triangulation.Delaunay.Sweep
{
	public class DTSweepContext : TriangulationContext
	{
		private const float ALPHA = 0.3f;

		public AdvancingFront Front;

		public readonly DTSweepBasin Basin = new DTSweepBasin();

		public readonly DTSweepEdgeEvent EdgeEvent = new DTSweepEdgeEvent();

		private readonly DTSweepPointComparator _comparator = new DTSweepPointComparator();

		private TriangulationPoint Head { get; set; }

		private TriangulationPoint Tail { get; set; }

		public override TriangulationAlgorithm Algorithm
		{
			get
			{
				return TriangulationAlgorithm.DTSweep;
			}
		}

		public new DTSweepDebugContext DebugContext
		{
			get
			{
				return (DTSweepDebugContext)base.DebugContext;
			}
		}

		public DTSweepContext()
			: base(new DTSweepDebugContext())
		{
		}

		public void RemoveFromList(DelaunayTriangle triangle)
		{
			Triangles.Remove(triangle);
		}

		public void MeshClean(DelaunayTriangle triangle)
		{
			MeshCleanReq(triangle);
		}

		private void MeshCleanReq(DelaunayTriangle triangle)
		{
			if (triangle == null || triangle.IsInterior)
			{
				return;
			}
			triangle.IsInterior = true;
			base.Triangulatable.AddTriangle(triangle);
			for (int i = 0; i < 3; i++)
			{
				if (!triangle.EdgeIsConstrained[i])
				{
					MeshCleanReq(triangle.Neighbors[i]);
				}
			}
		}

		public AdvancingFrontNode LocateNode(TriangulationPoint point)
		{
			return Front.LocateNode(point);
		}

		public void CreateAdvancingFront()
		{
			DelaunayTriangle delaunayTriangle = new DelaunayTriangle(Points[0], Tail, Head);
			Triangles.Add(delaunayTriangle);
			AdvancingFrontNode head = new AdvancingFrontNode(delaunayTriangle.Points[1])
			{
				Triangle = delaunayTriangle
			};
			AdvancingFrontNode advancingFrontNode = new AdvancingFrontNode(delaunayTriangle.Points[0])
			{
				Triangle = delaunayTriangle
			};
			AdvancingFrontNode tail = new AdvancingFrontNode(delaunayTriangle.Points[2]);
			Front = new AdvancingFront(head, tail)
			{
				Head = 
				{
					Next = advancingFrontNode
				}
			};
			advancingFrontNode.Next = Front.Tail;
			advancingFrontNode.Prev = Front.Head;
			Front.Tail.Prev = advancingFrontNode;
		}

		public void MapTriangleToNodes(DelaunayTriangle t)
		{
			for (int i = 0; i < 3; i++)
			{
				if (t.Neighbors[i] == null)
				{
					AdvancingFrontNode advancingFrontNode = Front.LocatePoint(t.PointCWFrom(t.Points[i]));
					if (advancingFrontNode != null)
					{
						advancingFrontNode.Triangle = t;
					}
				}
			}
		}

		public override void PrepareTriangulation(ITriangulatable t)
		{
			base.PrepareTriangulation(t);
			double x;
			double num = (x = Points[0].X);
			double y;
			double num2 = (y = Points[0].Y);
			foreach (TriangulationPoint point in Points)
			{
				if (point.X > num)
				{
					num = point.X;
				}
				if (point.X < x)
				{
					x = point.X;
				}
				if (point.Y > num2)
				{
					num2 = point.Y;
				}
				if (point.Y < y)
				{
					y = point.Y;
				}
			}
			double num3 = 0.30000001192092896 * (num - x);
			double num4 = 0.30000001192092896 * (num2 - y);
			TriangulationPoint head = new TriangulationPoint(num + num3, y - num4);
			TriangulationPoint tail = new TriangulationPoint(x - num3, y - num4);
			Head = head;
			Tail = tail;
			Points.Sort(_comparator);
		}

		public void FinalizeTriangulation()
		{
			base.Triangulatable.AddTriangles(Triangles);
			Triangles.Clear();
		}

		public override DTSweepConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b)
		{
			return new DTSweepConstraint(a, b);
		}
	}
}
