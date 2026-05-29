namespace Pathfinding.Poly2Tri
{
	public class DTSweepContext : TriangulationContext
	{
		private readonly float ALPHA;

		public AdvancingFront Front;

		public DTSweepBasin Basin;

		public DTSweepEdgeEvent EdgeEvent;

		private DTSweepPointComparator _comparator;

		public TriangulationPoint Head { get; set; }

		public TriangulationPoint Tail { get; set; }

		public override bool IsDebugEnabled
		{
			get
			{
				return false;
			}
			protected set
			{
			}
		}

		public override TriangulationAlgorithm Algorithm => default(TriangulationAlgorithm);

		public void RemoveFromList(DelaunayTriangle triangle)
		{
		}

		public void MeshClean(DelaunayTriangle triangle)
		{
		}

		private void MeshCleanReq(DelaunayTriangle triangle)
		{
		}

		public override void Clear()
		{
		}

		public void AddNode(AdvancingFrontNode node)
		{
		}

		public void RemoveNode(AdvancingFrontNode node)
		{
		}

		public AdvancingFrontNode LocateNode(TriangulationPoint point)
		{
			return null;
		}

		public void CreateAdvancingFront()
		{
		}

		public void MapTriangleToNodes(DelaunayTriangle t)
		{
		}

		public override void PrepareTriangulation(Triangulatable t)
		{
		}

		public void FinalizeTriangulation()
		{
		}

		public override TriangulationConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b)
		{
			return null;
		}
	}
}
