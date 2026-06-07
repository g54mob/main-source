using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class TriangulationPoint : Point2D
	{
		public static readonly double kVertexCodeDefaultPrecision;

		protected uint mVertexCode;

		public override double X
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public override double Y
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public uint VertexCode => 0u;

		public List<DTSweepConstraint> Edges { get; private set; }

		public bool HasEdges => false;

		public TriangulationPoint(double x, double y)
		{
		}

		public TriangulationPoint(double x, double y, double precision)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override void Set(double x, double y)
		{
		}

		public static uint CreateVertexCode(double x, double y, double precision)
		{
			return 0u;
		}

		public void AddEdge(DTSweepConstraint e)
		{
		}

		public bool HasEdge(TriangulationPoint p)
		{
			return false;
		}

		public bool GetEdge(TriangulationPoint p, out DTSweepConstraint edge)
		{
			edge = null;
			return false;
		}

		public static Point2D ToPoint2D(TriangulationPoint p)
		{
			return null;
		}
	}
}
