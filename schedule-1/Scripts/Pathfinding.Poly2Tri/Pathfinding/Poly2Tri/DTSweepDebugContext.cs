namespace Pathfinding.Poly2Tri
{
	public class DTSweepDebugContext : TriangulationDebugContext
	{
		private DelaunayTriangle _primaryTriangle;

		private DelaunayTriangle _secondaryTriangle;

		private TriangulationPoint _activePoint;

		private AdvancingFrontNode _activeNode;

		private DTSweepConstraint _activeConstraint;

		public DelaunayTriangle PrimaryTriangle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DelaunayTriangle SecondaryTriangle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TriangulationPoint ActivePoint
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AdvancingFrontNode ActiveNode
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DTSweepConstraint ActiveConstraint
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsDebugContext => false;

		public DTSweepDebugContext(DTSweepContext tcx)
			: base(null)
		{
		}

		public override void Clear()
		{
		}
	}
}
