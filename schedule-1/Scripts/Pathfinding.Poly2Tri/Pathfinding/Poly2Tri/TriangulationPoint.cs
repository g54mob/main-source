using System.Collections.Generic;

namespace Pathfinding.Poly2Tri
{
	public class TriangulationPoint
	{
		public double X;

		public double Y;

		public List<DTSweepConstraint> Edges { get; private set; }

		public float Xf
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Yf
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool HasEdges => false;

		public TriangulationPoint(double x, double y)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void AddEdge(DTSweepConstraint e)
		{
		}
	}
}
