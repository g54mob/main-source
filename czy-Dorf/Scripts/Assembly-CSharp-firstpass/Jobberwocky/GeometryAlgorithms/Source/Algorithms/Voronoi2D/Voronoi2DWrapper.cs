using System.Collections.Generic;
using System.Linq;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using Jobberwocky.TriangleNet;
using Jobberwocky.TriangleNet.Geometry;
using Jobberwocky.TriangleNet.Meshing;
using Jobberwocky.TriangleNet.Topology.DCEL;
using Jobberwocky.TriangleNet.Voronoi;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Algorithms.Voronoi2D
{
	public class Voronoi2DWrapper
	{
		public Geometry Voronoi2D(Voronoi2DParameters parameters)
		{
			return Voronoi2DBase(parameters);
		}

		private Geometry Voronoi2DBase(Voronoi2DParameters parameters)
		{
			Geometry geometry = new Geometry();
			if (parameters == null)
			{
				parameters = new Voronoi2DParameters();
			}
			Vector3[] points = parameters.Points;
			if (points != null && points.Length > 2)
			{
				Jobberwocky.TriangleNet.Geometry.Vertex[] array = VectorToVertex(points, parameters.CoordinateSystem);
				Polygon polygon = new Polygon();
				for (int i = 0; i < array.Length; i++)
				{
					polygon.Add(array[i]);
				}
				ConstraintOptions options = new ConstraintOptions
				{
					ConformingDelaunay = true
				};
				Jobberwocky.TriangleNet.Mesh mesh = (Jobberwocky.TriangleNet.Mesh)ExtensionMethods.Triangulate(polygon, options);
				VoronoiBase voronoiBase = ((!parameters.Bounded) ? ((VoronoiBase)new StandardVoronoi(mesh)) : ((VoronoiBase)new BoundedVoronoi(mesh)));
				Jobberwocky.TriangleNet.Topology.DCEL.Vertex[] array2 = voronoiBase.Vertices.ToArray();
				IEdge[] array3 = Enumerable.ToArray(voronoiBase.Edges);
				HalfEdge[] array4 = voronoiBase.HalfEdges.ToArray();
				Face[] array5 = voronoiBase.Faces.ToArray();
				Jobberwocky.GeometryAlgorithms.Source.Core.Vertex[] array6 = new Jobberwocky.GeometryAlgorithms.Source.Core.Vertex[array2.Length];
				foreach (Jobberwocky.TriangleNet.Topology.DCEL.Vertex vertex in array2)
				{
					array6[vertex.ID] = new Jobberwocky.GeometryAlgorithms.Source.Core.Vertex(Utils.FromCoordinateSystemDefaultTo(new Vector3((float)vertex.X, (float)vertex.Y, (float)vertex.Z), parameters.CoordinateSystem), vertex.ID);
				}
				int[] array7 = new int[array3.Length * 2];
				for (int k = 0; k < array3.Length; k++)
				{
					IEdge edge = array3[k];
					array7[k * 2] = edge.P0;
					array7[k * 2 + 1] = edge.P1;
				}
				Dictionary<int, Jobberwocky.GeometryAlgorithms.Source.Core.Vertex>[] array8 = new Dictionary<int, Jobberwocky.GeometryAlgorithms.Source.Core.Vertex>[array5.Length];
				for (int l = 0; l < array5.Length; l++)
				{
					array8[l] = new Dictionary<int, Jobberwocky.GeometryAlgorithms.Source.Core.Vertex>();
				}
				foreach (HalfEdge halfEdge in array4)
				{
					if (halfEdge.Face.ID != -1)
					{
						Dictionary<int, Jobberwocky.GeometryAlgorithms.Source.Core.Vertex> dictionary = array8[halfEdge.Face.ID];
						if (!dictionary.ContainsKey(halfEdge.Origin.ID))
						{
							dictionary.Add(halfEdge.Origin.ID, array6[halfEdge.Origin.ID]);
						}
						if (!dictionary.ContainsKey(halfEdge.Twin.Origin.ID))
						{
							dictionary.Add(halfEdge.Twin.Origin.ID, array6[halfEdge.Twin.Origin.ID]);
						}
					}
				}
				Geometry[] array9 = new Geometry[array5.Length];
				for (int n = 0; n < array8.Length; n++)
				{
					array9[n] = new Geometry
					{
						Vertices = Enumerable.ToArray(array8[n].Values)
					};
				}
				geometry.Vertices = array6;
				geometry.Indices = array7;
				geometry.Cells = array9;
				geometry.Topology = MeshTopology.Lines;
			}
			return geometry;
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
