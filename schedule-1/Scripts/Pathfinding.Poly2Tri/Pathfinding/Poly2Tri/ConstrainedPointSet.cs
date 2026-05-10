using System.Collections.Generic;

namespace Pathfinding.Poly2Tri
{
	public class ConstrainedPointSet : PointSet
	{
		public int[] EdgeIndex { get; private set; }

		public override TriangulationMode TriangulationMode => default(TriangulationMode);

		public ConstrainedPointSet(List<TriangulationPoint> points, int[] index)
			: base(null)
		{
		}

		public override void Prepare(TriangulationContext tcx)
		{
		}
	}
}
