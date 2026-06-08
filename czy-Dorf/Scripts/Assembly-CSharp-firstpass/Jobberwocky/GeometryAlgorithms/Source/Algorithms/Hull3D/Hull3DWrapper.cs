using System.Linq;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using Jobberwocky.MIConvexHull;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Algorithms.Hull3D
{
	public class Hull3DWrapper
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

		public Geometry Hull3D(Hull3DParameters parameters)
		{
			return Hull3DBase(parameters);
		}

		private Geometry Hull3DBase(Hull3DParameters parameters)
		{
			Geometry geometry = new Geometry();
			if (parameters == null)
			{
				parameters = new Hull3DParameters();
			}
			Vector3[] points = parameters.Points;
			if (points != null && points.Length > 3)
			{
				ConvexHullCreationResult<VertexId, DefaultConvexFace<VertexId>> convexHullCreationResult = ConvexHull.Create(VectorToVertex(points, parameters.CoordinateSystem));
				Vertex[] array = new Vertex[Enumerable.Count(convexHullCreationResult.Result.Points)];
				int[] array2 = new int[Enumerable.Count(convexHullCreationResult.Result.Faces) * 3];
				int num = 0;
				foreach (VertexId point in convexHullCreationResult.Result.Points)
				{
					point.Id = num;
					array[num] = new Vertex(Utils.FromCoordinateSystemDefaultTo(new Vector3((float)point.Position[0], (float)point.Position[1], (float)point.Position[2]), parameters.CoordinateSystem), num);
					num++;
				}
				int num2 = 0;
				foreach (DefaultConvexFace<VertexId> face in convexHullCreationResult.Result.Faces)
				{
					VertexId[] vertices = face.Vertices;
					foreach (VertexId vertexId in vertices)
					{
						array2[num2] = vertexId.Id;
						num2++;
					}
				}
				geometry.Vertices = array;
				geometry.Indices = array2;
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
