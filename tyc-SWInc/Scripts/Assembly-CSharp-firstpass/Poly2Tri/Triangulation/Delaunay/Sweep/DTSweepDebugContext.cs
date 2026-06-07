namespace Poly2Tri.Triangulation.Delaunay.Sweep
{
	public class DTSweepDebugContext : TriangulationDebugContext
	{
		public DelaunayTriangle PrimaryTriangle { get; set; }

		public DelaunayTriangle SecondaryTriangle { get; set; }

		public TriangulationPoint ActivePoint { get; set; }

		public AdvancingFrontNode ActiveNode { get; set; }

		public DTSweepConstraint ActiveConstraint { get; set; }

		public bool IsDebugContext
		{
			get
			{
				return true;
			}
		}

		public override void Clear()
		{
			PrimaryTriangle = null;
			SecondaryTriangle = null;
			ActivePoint = null;
			ActiveNode = null;
			ActiveConstraint = null;
		}
	}
}
