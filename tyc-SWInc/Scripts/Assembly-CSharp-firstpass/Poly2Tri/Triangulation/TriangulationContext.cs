using System.Collections.Generic;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Delaunay.Sweep;

namespace Poly2Tri.Triangulation
{
	public abstract class TriangulationContext
	{
		public readonly List<DelaunayTriangle> Triangles = new List<DelaunayTriangle>();

		public readonly List<TriangulationPoint> Points = new List<TriangulationPoint>(200);

		protected TriangulationDebugContext DebugContext { get; private set; }

		public bool IsDebugEnabled { get; protected set; }

		public TriangulationMode TriangulationMode { get; private set; }

		public ITriangulatable Triangulatable { get; private set; }

		public abstract TriangulationAlgorithm Algorithm { get; }

		protected TriangulationContext(TriangulationDebugContext debug)
		{
			DebugContext = debug;
		}

		public virtual void PrepareTriangulation(ITriangulatable t)
		{
			Triangulatable = t;
			TriangulationMode = t.TriangulationMode;
			t.Prepare(this);
		}

		public virtual void Clear()
		{
			Points.Clear();
			Triangles.Clear();
			if (DebugContext != null)
			{
				DebugContext.Clear();
			}
		}

		public abstract DTSweepConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b);
	}
}
