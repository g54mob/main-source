using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class ConstrainedPointSet : PointSet
	{
		protected Dictionary<uint, TriangulationConstraint> mConstraintMap;

		protected List<Contour> mHoles;

		public override TriangulationMode TriangulationMode => default(TriangulationMode);

		public ConstrainedPointSet(List<TriangulationPoint> bounds)
			: base(null)
		{
		}

		public ConstrainedPointSet(List<TriangulationPoint> bounds, List<TriangulationConstraint> constraints)
			: base(null)
		{
		}

		public ConstrainedPointSet(List<TriangulationPoint> bounds, int[] indices)
			: base(null)
		{
		}

		protected void AddBoundaryConstraints()
		{
		}

		public override void Add(Point2D p)
		{
		}

		public override void Add(TriangulationPoint p)
		{
		}

		public override bool AddRange(List<TriangulationPoint> points)
		{
			return false;
		}

		public bool AddHole(List<TriangulationPoint> points, string name)
		{
			return false;
		}

		public bool AddConstraints(List<TriangulationConstraint> constraints)
		{
			return false;
		}

		public bool AddConstraint(TriangulationConstraint tc)
		{
			return false;
		}

		public bool TryGetConstraint(uint constraintCode, out TriangulationConstraint tc)
		{
			tc = null;
			return false;
		}

		public int GetNumConstraints()
		{
			return 0;
		}

		public Dictionary<uint, TriangulationConstraint>.Enumerator GetConstraintEnumerator()
		{
			return default(Dictionary<uint, TriangulationConstraint>.Enumerator);
		}

		public int GetNumHoles()
		{
			return 0;
		}

		public Contour GetHole(int idx)
		{
			return null;
		}

		public int GetActualHoles(out List<Contour> holes)
		{
			holes = null;
			return 0;
		}

		protected void InitializeHoles()
		{
		}

		public override bool Initialize()
		{
			return false;
		}

		public override void Prepare(TriangulationContext tcx)
		{
		}

		public override void AddTriangle(DelaunayTriangle t)
		{
		}
	}
}
