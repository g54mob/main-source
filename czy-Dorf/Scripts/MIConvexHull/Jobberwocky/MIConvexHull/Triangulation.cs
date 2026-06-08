using System.Collections.Generic;

namespace Jobberwocky.MIConvexHull
{
	public static class Triangulation
	{
		public static ITriangulation<TVertex, DefaultTriangulationCell<TVertex>> CreateDelaunay<TVertex>(IList<TVertex> data, double PlaneDistanceTolerance = 1E-10) where TVertex : IVertex
		{
			return DelaunayTriangulation<TVertex, DefaultTriangulationCell<TVertex>>.Create(data, PlaneDistanceTolerance);
		}
	}
}
