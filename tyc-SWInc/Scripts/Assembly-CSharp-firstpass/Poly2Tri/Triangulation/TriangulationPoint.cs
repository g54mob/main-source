using System;
using System.Collections.Generic;
using System.Linq;
using Poly2Tri.Triangulation.Delaunay.Sweep;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation
{
	public class TriangulationPoint : Point2D, IEquatable<TriangulationPoint>
	{
		public int I;

		public const double VERTEX_CODE_DEFAULT_PRECISION = 3.0;

		public override double X
		{
			get
			{
				return base.X;
			}
			set
			{
				if (value != base.X)
				{
					base.X = value;
					VertexCode = CreateVertexCode(base.X, base.Y, 3.0);
				}
			}
		}

		public override double Y
		{
			get
			{
				return base.Y;
			}
			set
			{
				if (value != base.Y)
				{
					base.Y = value;
					VertexCode = CreateVertexCode(base.X, base.Y, 3.0);
				}
			}
		}

		public uint VertexCode { get; private set; }

		public List<DTSweepConstraint> Edges { get; private set; }

		public bool HasEdges
		{
			get
			{
				return Edges != null;
			}
		}

		public TriangulationPoint(double x, double y, double precision = 3.0, int i = 0)
			: base(x, y)
		{
			VertexCode = CreateVertexCode(x, y, precision);
			I = i;
		}

		public override string ToString()
		{
			return base.ToString() + ":{" + VertexCode + "}";
		}

		public override int GetHashCode()
		{
			return (int)VertexCode;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as TriangulationPoint);
		}

		public bool Equals(TriangulationPoint other)
		{
			if (other == null)
			{
				return false;
			}
			if (VertexCode == other.VertexCode)
			{
				return Equals(other, 0.0);
			}
			return false;
		}

		public override void Set(double x, double y)
		{
			X = x;
			Y = y;
		}

		public static uint CreateVertexCode(double x, double y, double precision)
		{
			float value = (float)MathUtil.RoundWithPrecision(x, precision);
			float value2 = (float)MathUtil.RoundWithPrecision(y, precision);
			uint nInitialValue = MathUtil.Jenkins32Hash(BitConverter.GetBytes(value), 0u);
			return MathUtil.Jenkins32Hash(BitConverter.GetBytes(value2), nInitialValue);
		}

		public void AddEdge(DTSweepConstraint e)
		{
			if (Edges == null)
			{
				Edges = new List<DTSweepConstraint>();
			}
			Edges.Add(e);
		}

		public bool HasEdge(TriangulationPoint p)
		{
			DTSweepConstraint edge;
			return GetEdge(p, out edge);
		}

		public bool GetEdge(TriangulationPoint p, out DTSweepConstraint edge)
		{
			edge = null;
			if (Edges == null || Edges.Count < 1 || p == null || p.Equals(this))
			{
				return false;
			}
			using (IEnumerator<DTSweepConstraint> enumerator = Edges.Where((DTSweepConstraint sc) => (sc.P.Equals(this) && sc.Q.Equals(p)) || (sc.P.Equals(p) && sc.Q.Equals(this))).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					DTSweepConstraint current = enumerator.Current;
					edge = current;
					return true;
				}
			}
			return false;
		}
	}
}
