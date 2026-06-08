using System.Collections.Generic;
using Jobberwocky.TriangleNet.Geometry;
using Jobberwocky.TriangleNet.Topology;

namespace Jobberwocky.TriangleNet.Meshing
{
	public interface IMesh
	{
		ICollection<Vertex> Vertices { get; }

		ICollection<Triangle> Triangles { get; }

		void Renumber();
	}
}
