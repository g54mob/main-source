using System.Collections.Generic;
using System.Linq;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using Jobberwocky.MIConvexHull;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Algorithms.Voronoi3D
{
	public class Voronoi3DWrapper
	{
		private class VertexId : DefaultVertex
		{
			private int _003CId_003Ek__BackingField;

			public int Id
			{
				get
				{
					return _003CId_003Ek__BackingField;
				}
				set
				{
					_003CId_003Ek__BackingField = value;
				}
			}
		}

		public Geometry Voronoi3D(Voronoi3DParameters parameters)
		{
			return Voronoi3DBase(parameters);
		}

		private Geometry Voronoi3DBase(Voronoi3DParameters parameters)
		{
			Geometry geometry = new Geometry();
			if (parameters == null)
			{
				parameters = new Voronoi3DParameters();
			}
			Vector3[] points = parameters.Points;
			if (points != null && points.Length > 3)
			{
				VertexId[] data = VectorToVertex(points, parameters.CoordinateSystem);
				float num = float.PositiveInfinity;
				float num2 = float.PositiveInfinity;
				float num3 = float.PositiveInfinity;
				float num4 = float.NegativeInfinity;
				float num5 = float.NegativeInfinity;
				float num6 = float.NegativeInfinity;
				Vector3[] array = points;
				for (int i = 0; i < array.Length; i++)
				{
					Vector3 vector = array[i];
					num = ((num > vector.x) ? vector.x : num);
					num2 = ((num2 > vector.y) ? vector.y : num2);
					num3 = ((num3 > vector.z) ? vector.z : num3);
					num4 = ((num4 < vector.x) ? vector.x : num4);
					num5 = ((num5 < vector.y) ? vector.y : num5);
					num6 = ((num6 < vector.z) ? vector.z : num6);
				}
				VoronoiMesh<VertexId, DefaultTriangulationCell<VertexId>, VoronoiEdge<VertexId, DefaultTriangulationCell<VertexId>>> voronoiMesh = VoronoiMesh.Create(data);
				Dictionary<string, Vertex> dictionary = new Dictionary<string, Vertex>();
				List<int> list = new List<int>();
				int num7 = 0;
				foreach (VoronoiEdge<VertexId, DefaultTriangulationCell<VertexId>> edge in voronoiMesh.Edges)
				{
					Vertex vertex = GetCircumcenter(edge.Source.Vertices, parameters.CoordinateSystem);
					Vertex vertex2 = GetCircumcenter(edge.Target.Vertices, parameters.CoordinateSystem);
					if (!(vertex.Position.x < num) && !(vertex.Position.y < num2) && !(vertex.Position.z < num3) && !(vertex.Position.x > num4) && !(vertex.Position.y > num5) && !(vertex.Position.z > num6) && !(vertex2.Position.x < num) && !(vertex2.Position.y < num2) && !(vertex2.Position.z < num3) && !(vertex2.Position.x > num4) && !(vertex2.Position.y > num5) && !(vertex2.Position.z > num6))
					{
						string uniqueID = GetUniqueID(edge.Source.Vertices);
						if (!dictionary.ContainsKey(uniqueID))
						{
							vertex.Index = num7++;
							dictionary.Add(uniqueID, vertex);
						}
						else
						{
							vertex = dictionary[uniqueID];
						}
						string uniqueID2 = GetUniqueID(edge.Target.Vertices);
						if (!dictionary.ContainsKey(uniqueID2))
						{
							vertex2.Index = num7++;
							dictionary.Add(uniqueID2, vertex2);
						}
						else
						{
							vertex2 = dictionary[uniqueID2];
						}
						list.Add(vertex.Index);
						list.Add(vertex2.Index);
					}
				}
				geometry.Vertices = Enumerable.ToArray(dictionary.Values);
				geometry.Indices = list.ToArray();
				geometry.Topology = MeshTopology.Lines;
			}
			return geometry;
		}

		private string GetUniqueID(VertexId[] vertices)
		{
			string text = "";
			foreach (VertexId vertexId in vertices)
			{
				text += vertexId.Id;
			}
			return text;
		}

		private Vertex GetCircumcenter(VertexId[] vertices, CoordinateSystem coordinateSystem)
		{
			Vector3[] array = new Vector3[vertices.Length];
			for (int i = 0; i < vertices.Length; i++)
			{
				array[i] = Utils.FromCoordinateSystemDefaultTo(new Vector3((float)vertices[i].Position[0], (float)vertices[i].Position[1], (float)vertices[i].Position[2]), coordinateSystem);
			}
			Matrix4x4 matrix4x = default(Matrix4x4);
			for (int j = 0; j < 4; j++)
			{
				matrix4x.SetRow(j, new Vector4(array[j].x, array[j].y, array[j].z, 1f));
			}
			float determinant = matrix4x.determinant;
			for (int k = 0; k < 4; k++)
			{
				matrix4x[k, 0] = array[k].sqrMagnitude;
			}
			float determinant2 = matrix4x.determinant;
			for (int l = 0; l < 4; l++)
			{
				matrix4x[l, 1] = array[l].x;
			}
			float num = 0f - matrix4x.determinant;
			for (int m = 0; m < 4; m++)
			{
				matrix4x[m, 2] = array[m].y;
			}
			float determinant3 = matrix4x.determinant;
			for (int n = 0; n < 4; n++)
			{
				matrix4x[n, 3] = array[n].z;
			}
			float num2 = 1f / (2f * determinant);
			return new Vertex(num2 * determinant2, num2 * num, num2 * determinant3);
		}

		private VertexId[] VectorToVertex(Vector3[] vectors, CoordinateSystem coordinateSystem)
		{
			VertexId[] array = new VertexId[vectors.Length];
			for (int i = 0; i < vectors.Length; i++)
			{
				Vector3 vector = Utils.ToCoordinateSystemDefault(vectors[i], coordinateSystem);
				array[i] = new VertexId
				{
					Position = new double[3] { vector.x, vector.y, vector.z },
					Id = i
				};
			}
			return array;
		}
	}
}
