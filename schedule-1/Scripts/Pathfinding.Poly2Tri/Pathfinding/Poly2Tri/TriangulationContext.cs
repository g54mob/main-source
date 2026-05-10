using System.Collections.Generic;

namespace Pathfinding.Poly2Tri
{
	public abstract class TriangulationContext
	{
		public readonly List<DelaunayTriangle> Triangles;

		public readonly List<TriangulationPoint> Points;

		public TriangulationDebugContext DebugContext { get; protected set; }

		public TriangulationMode TriangulationMode { get; protected set; }

		public Triangulatable Triangulatable { get; private set; }

		public int StepCount { get; private set; }

		public abstract TriangulationAlgorithm Algorithm { get; }

		public virtual bool IsDebugEnabled { get; protected set; }

		public DTSweepDebugContext DTDebugContext => null;

		public void Done()
		{
		}

		public virtual void PrepareTriangulation(Triangulatable t)
		{
		}

		public abstract TriangulationConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b);

		public void Update(string message)
		{
		}

		public virtual void Clear()
		{
		}
	}
}
