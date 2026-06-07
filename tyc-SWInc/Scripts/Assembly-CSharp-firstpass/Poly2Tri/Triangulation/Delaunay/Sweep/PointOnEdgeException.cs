using System;

namespace Poly2Tri.Triangulation.Delaunay.Sweep
{
	public class PointOnEdgeException : NotImplementedException
	{
		public TriangulationPoint A { get; set; }

		public TriangulationPoint B { get; set; }

		public TriangulationPoint C { get; set; }

		public PointOnEdgeException(string message, TriangulationPoint a, TriangulationPoint b, TriangulationPoint c)
			: base(message)
		{
			A = a;
			B = b;
			C = c;
		}
	}
}
