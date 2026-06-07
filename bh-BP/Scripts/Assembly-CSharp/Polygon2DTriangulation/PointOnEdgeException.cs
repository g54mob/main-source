using System;

namespace Polygon2DTriangulation
{
	public class PointOnEdgeException : NotImplementedException
	{
		public readonly TriangulationPoint A;

		public readonly TriangulationPoint B;

		public readonly TriangulationPoint C;

		public PointOnEdgeException(string message, TriangulationPoint a, TriangulationPoint b, TriangulationPoint c)
		{
		}
	}
}
