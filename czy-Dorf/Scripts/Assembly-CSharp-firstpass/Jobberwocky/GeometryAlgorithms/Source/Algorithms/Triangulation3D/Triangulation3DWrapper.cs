using System;
using System.Collections.Generic;
using System.Linq;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using Jobberwocky.MIConvexHull;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Algorithms.Triangulation3D
{
	public class Triangulation3DWrapper
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

		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Comparison<VertexId> _003C_003E9__2_0;

			internal int _003CTriangulate3DBase_003Eb__2_0(VertexId a, VertexId b)
			{
				return a.Position[0].CompareTo(b.Position[0]);
			}
		}

		public Geometry Triangulate3D(Triangulation3DParameters parameters)
		{
			return Triangulate3DBase(parameters);
		}

		private Geometry Triangulate3DBase(Triangulation3DParameters parameters)
		{
			Geometry geometry = new Geometry();
			if (parameters == null)
			{
				parameters = new Triangulation3DParameters();
			}
			Vector3[] points = parameters.Points;
			if (points != null && points.Length > 3)
			{
				VertexId[] array = VectorToVertex(points, parameters.CoordinateSystem);
				DefaultTriangulationCell<VertexId>[] array2;
				if (points.Length == 4)
				{
					List<VertexId> list = Enumerable.ToList(array);
					list.Sort((VertexId a, VertexId b) => a.Position[0].CompareTo(b.Position[0]));
					DefaultTriangulationCell<VertexId> defaultTriangulationCell = new DefaultTriangulationCell<VertexId>();
					defaultTriangulationCell.Vertices = list.ToArray();
					defaultTriangulationCell.Adjacency = new DefaultTriangulationCell<VertexId>[4];
					array2 = new DefaultTriangulationCell<VertexId>[1] { defaultTriangulationCell };
				}
				else
				{
					array2 = Enumerable.ToArray(Triangulation.CreateDelaunay(array).Cells);
				}
				Dictionary<int, Vertex> dictionary = new Dictionary<int, Vertex>();
				List<int> list2 = new List<int>();
				int num = 0;
				foreach (DefaultTriangulationCell<VertexId> defaultTriangulationCell2 in array2)
				{
					int[] array3 = new int[defaultTriangulationCell2.Vertices.Length];
					for (int num3 = 0; num3 < defaultTriangulationCell2.Vertices.Length; num3++)
					{
						Vertex vertex = new Vertex(Utils.FromCoordinateSystemDefaultTo(new Vector3((float)defaultTriangulationCell2.Vertices[num3].Position[0], (float)defaultTriangulationCell2.Vertices[num3].Position[1], (float)defaultTriangulationCell2.Vertices[num3].Position[2]), parameters.CoordinateSystem), defaultTriangulationCell2.Vertices[num3].Id);
						if (!dictionary.ContainsKey(vertex.Id))
						{
							vertex.Index = num++;
							dictionary.Add(vertex.Id, vertex);
						}
						else
						{
							vertex.Index = dictionary[vertex.Id].Index;
						}
						array3[num3] = vertex.Index;
					}
					for (int num4 = 0; num4 < defaultTriangulationCell2.Adjacency.Length; num4++)
					{
						if (!parameters.BoundaryOnly || defaultTriangulationCell2.Adjacency[num4] == null)
						{
							switch (num4)
							{
							case 0:
								list2.Add(array3[2]);
								list2.Add(array3[1]);
								list2.Add(array3[3]);
								break;
							case 1:
								list2.Add(array3[0]);
								list2.Add(array3[2]);
								list2.Add(array3[3]);
								break;
							case 2:
								list2.Add(array3[3]);
								list2.Add(array3[1]);
								list2.Add(array3[0]);
								break;
							case 3:
								list2.Add(array3[1]);
								list2.Add(array3[2]);
								list2.Add(array3[0]);
								break;
							}
							if (parameters.Side == Side.Back)
							{
								int value = list2[list2.Count - 3];
								list2[list2.Count - 3] = list2[list2.Count - 1];
								list2[list2.Count - 1] = value;
							}
							if (parameters.Side == Side.Double)
							{
								list2.Add(list2[list2.Count - 1]);
								list2.Add(list2[list2.Count - 2]);
								list2.Add(list2[list2.Count - 3]);
							}
						}
					}
				}
				geometry.Vertices = Enumerable.ToArray(dictionary.Values);
				geometry.Indices = list2.ToArray();
			}
			return geometry;
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
