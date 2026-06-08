using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Algorithms.Hull2D
{
	public class Hull2DWrapper
	{
		public Geometry Hull2D(Hull2DParameters parameters)
		{
			return Hull2DBase(parameters);
		}

		private Geometry Hull2DBase(Hull2DParameters parameters)
		{
			Geometry geometry = new Geometry();
			if (parameters == null)
			{
				parameters = new Hull2DParameters();
			}
			Vector3[] points = parameters.Points;
			if (points != null && points.Length > 2)
			{
				Vertex[] array = new Hull2DAlgorithm().GenerateHull(VectorToVertex(points, parameters.CoordinateSystem), parameters.Concavity);
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Position = Utils.FromCoordinateSystemDefaultTo(array[i].Position, parameters.CoordinateSystem);
				}
				geometry.Vertices = array;
				geometry.Indices = new int[(array.Length - 1) * 2];
				geometry.Topology = MeshTopology.Lines;
				for (int j = 0; j < array.Length - 1; j++)
				{
					geometry.Indices[j * 2] = j;
					geometry.Indices[j * 2 + 1] = j + 1 % (array.Length - 1);
				}
			}
			return geometry;
		}

		private Vertex[] VectorToVertex(Vector3[] vectors, CoordinateSystem coordinateSystem)
		{
			Vertex[] array = new Vertex[vectors.Length];
			for (int i = 0; i < vectors.Length; i++)
			{
				Vector3 vector = Utils.ToCoordinateSystemDefault(vectors[i], coordinateSystem);
				array[i] = new Vertex(vector.x, vector.y, vector.z, i);
			}
			return array;
		}
	}
}
