using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	public class IcoSphere
	{
		public class Icosahedron
		{
			public Vector3[] Vertices;

			public int[] Triangles;

			private Vector3[] CreateVertices()
			{
				return null;
			}

			private int[] CreateTriangles()
			{
				return null;
			}
		}

		public static Vector3[] vertices;

		public static int[] triangleIndices;

		private static int[,] triangles;

		public static Mesh CreateSphere(int rSubdivisions)
		{
			return null;
		}

		private static void get_triangulation(int num, Icosahedron ico)
		{
		}

		private static int[,] triangulate(int num)
		{
			return null;
		}

		private static Vector2[] getUV(Vector3[] vertices)
		{
			return null;
		}

		private static Vector2 cartToLL(Vector3 point)
		{
			return default(Vector2);
		}

		private static float[,] getSubMatrix(int num)
		{
			return null;
		}
	}
}
