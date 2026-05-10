namespace Pathfinding.Poly2Tri
{
	public abstract class TriangulationDebugContext
	{
		protected TriangulationContext _tcx;

		public TriangulationDebugContext(TriangulationContext tcx)
		{
		}

		public abstract void Clear();
	}
}
