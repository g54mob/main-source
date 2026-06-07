using System.Collections.Generic;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation
{
	public interface ITriangulatable
	{
		IList<DelaunayTriangle> Triangles { get; }

		TriangulationMode TriangulationMode { get; }

		bool DisplayFlipX { get; set; }

		bool DisplayFlipY { get; set; }

		float DisplayRotate { get; set; }

		double Precision { get; set; }

		double MinX { get; }

		double MaxX { get; }

		double MinY { get; }

		double MaxY { get; }

		Rect2D Bounds { get; }

		void Prepare(TriangulationContext tcx);

		void AddTriangle(DelaunayTriangle t);

		void AddTriangles(IEnumerable<DelaunayTriangle> list);

		void ClearTriangles();
	}
}
