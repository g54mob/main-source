using UnityEngine;

namespace Dreamteck
{
	public class MeshUtility
	{
		private static Vector3[] tan1;

		private static Vector3[] tan2;

		public static int[] GeneratePlaneTriangles(int x, int z, bool flip, int startTriangleIndex = 0, int startVertex = 0)
		{
			return null;
		}

		public static int[] GeneratePlaneTriangles(ref int[] triangles, int x, int z, bool flip, int startTriangleIndex = 0, int startVertex = 0, bool reallocateArray = false)
		{
			return null;
		}

		public static void CalculateTangents(TS_Mesh mesh)
		{
		}

		public static void MakeDoublesided(Mesh input)
		{
		}

		public static void MakeDoublesided(TS_Mesh input)
		{
		}

		public static void MakeDoublesidedHalf(TS_Mesh input)
		{
		}

		public static void TransformMesh(TS_Mesh input, Matrix4x4 matrix)
		{
		}

		public static void TransformMesh(Mesh input, Matrix4x4 matrix)
		{
		}

		public static void TransformVertices(Vector3[] vertices, Matrix4x4 matrix)
		{
		}

		public static void TransformNormals(Vector3[] normals, Matrix4x4 matrix)
		{
		}

		public static string ToOBJString(Mesh mesh, Material[] materials)
		{
			return null;
		}

		public static Mesh Copy(Mesh input)
		{
			return null;
		}

		public static void Triangulate(Vector2[] points, ref int[] output)
		{
		}

		public static void FlipTriangles(ref int[] triangles)
		{
		}

		public static void FlipFaces(TS_Mesh input)
		{
		}

		public static void BreakMesh(Mesh input, bool keepNormals = true)
		{
		}

		private static float Area(Vector2[] points, int maxCount)
		{
			return 0f;
		}

		private static bool Snip(Vector2[] points, int u, int v, int w, int n, int[] V)
		{
			return false;
		}

		private static bool InsideTriangle(Vector2 A, Vector2 B, Vector2 C, Vector2 P)
		{
			return false;
		}
	}
}
