using Jobberwocky.GeometryAlgorithms.Source.Algorithms.Voronoi2D;
using Jobberwocky.GeometryAlgorithms.Source.Algorithms.Voronoi3D;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.API
{
	public class VoronoiAPI : ThreadingAPI
	{
		public Geometry Voronoi2DRaw(Voronoi2DParameters parameters)
		{
			return new Voronoi2DWrapper().Voronoi2D(parameters);
		}

		public Mesh Voronoi3D(Voronoi3DParameters parameters)
		{
			return Voronoi3DRaw(parameters).ToUnityMesh();
		}

		public Geometry Voronoi3DRaw(Voronoi3DParameters parameters)
		{
			return new Voronoi3DWrapper().Voronoi3D(parameters);
		}
	}
}
