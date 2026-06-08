using System.Linq;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using Jobberwocky.TriangleNet.Geometry;
using Jobberwocky.TriangleNet.Meshing;
using Jobberwocky.TriangleNet.Topology;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Algorithms.Triangulation2D
{
	public class Triangulation2DWrapper
	{
		public Geometry Triangulate2D(Triangulation2DParameters parameters)
		{
			Geometry geometry = new Geometry();
			if (parameters == null)
			{
				parameters = new Triangulation2DParameters();
			}
			if ((parameters.Points != null && parameters.Points.Length > 2) || (parameters.Boundary != null && parameters.Boundary.Length > 2))
			{
				IMesh mesh = Triangulate2DBase(parameters);
				mesh.Renumber();
				Jobberwocky.TriangleNet.Geometry.Vertex[] array = Enumerable.ToArray(mesh.Vertices);
				Triangle[] array2 = Enumerable.ToArray(mesh.Triangles);
				geometry.Vertices = new Jobberwocky.GeometryAlgorithms.Source.Core.Vertex[array.Length];
				foreach (Jobberwocky.TriangleNet.Geometry.Vertex vertex in array)
				{
					geometry.Vertices[vertex.ID] = new Jobberwocky.GeometryAlgorithms.Source.Core.Vertex(Utils.FromCoordinateSystemDefaultTo(new Vector3((float)vertex.X, (float)vertex.Y, (float)vertex.Z), parameters.CoordinateSystem), vertex.ID);
				}
				int[] array3 = new int[array2.Length * 3 * ((parameters.Side != Side.Double) ? 1 : 2)];
				for (int j = 0; j < array2.Length; j++)
				{
					for (int k = 0; k < 3; k++)
					{
						array3[j * 3 + k] = array2[j].GetVertexID(k);
					}
					if (parameters.Side == Side.Back)
					{
						int num = array3[j * 3];
						array3[j * 3] = array3[j * 3 + 2];
						array3[j * 3 + 2] = num;
					}
				}
				if (parameters.Side == Side.Double)
				{
					for (int l = 0; l < array3.Length / 2; l++)
					{
						array3[array3.Length / 2 + l] = array3[array3.Length / 2 - 1 - l];
					}
				}
				geometry.Indices = array3;
			}
			return geometry;
		}

		private IMesh Triangulate2DBase(Triangulation2DParameters parameters)
		{
			GenericMesher genericMesher = new GenericMesher();
			ConstraintOptions constraintOptions = new ConstraintOptions();
			constraintOptions.Convex = true;
			constraintOptions.ConformingDelaunay = parameters.Delaunay;
			Polygon polygon = new Polygon();
			Vector3[] points = parameters.Points;
			if (points != null)
			{
				Jobberwocky.TriangleNet.Geometry.Vertex[] array = VectorToVertex(points, parameters.CoordinateSystem);
				for (int i = 0; i < array.Length; i++)
				{
					polygon.Add(array[i]);
				}
			}
			Vector3[] boundary = parameters.Boundary;
			if (boundary != null)
			{
				Jobberwocky.TriangleNet.Geometry.Vertex[] points2 = VectorToVertex(boundary, parameters.CoordinateSystem);
				polygon.Add(new Contour(points2));
				constraintOptions.Convex = false;
			}
			Vector3[][] holes = parameters.Holes;
			if (holes != null)
			{
				for (int j = 0; j < holes.Length; j++)
				{
					Jobberwocky.TriangleNet.Geometry.Vertex[] points3 = VectorToVertex(holes[j], parameters.CoordinateSystem);
					polygon.Add(new Contour(points3), hole: true);
				}
			}
			return genericMesher.Triangulate(polygon, constraintOptions);
		}

		private Jobberwocky.TriangleNet.Geometry.Vertex[] VectorToVertex(Vector3[] vectors, CoordinateSystem coordinateSystem)
		{
			Jobberwocky.TriangleNet.Geometry.Vertex[] array = new Jobberwocky.TriangleNet.Geometry.Vertex[vectors.Length];
			for (int i = 0; i < vectors.Length; i++)
			{
				Vector3 vector = Utils.ToCoordinateSystemDefault(vectors[i], coordinateSystem);
				Jobberwocky.TriangleNet.Geometry.Vertex vertex = new Jobberwocky.TriangleNet.Geometry.Vertex(vector.x, vector.y);
				vertex.Z = vector.z;
				array[i] = vertex;
			}
			return array;
		}
	}
}
