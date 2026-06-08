using System.Collections.Generic;
using Jobberwocky.TriangleNet.Geometry;

namespace Jobberwocky.TriangleNet.Meshing
{
	public interface ITriangulator
	{
		IMesh Triangulate(IList<Vertex> points, Configuration config);
	}
}
