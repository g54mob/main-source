using UnityEngine;

namespace AmplifyImpostors
{
	public static class Vector2Ex
	{
		public static float Cross(this Vector2 O, Vector2 A, Vector2 B)
		{
			return 0f;
		}

		public static float TriangleArea(this Vector2 O, Vector2 A, Vector2 B)
		{
			return 0f;
		}

		public static float TriangleArea(this Vector3 O, Vector3 A, Vector3 B)
		{
			return 0f;
		}

		public static Vector2[] ConvexHull(Vector2[] P)
		{
			return null;
		}

		public static Vector2[] ScaleAlongNormals(Vector2[] P, float scaleAmount)
		{
			return null;
		}

		private static Vector2[] ReduceLeastSignificantVertice(Vector2[] P)
		{
			return null;
		}

		public static Vector2[] ReduceVertices(Vector2[] P, int maxVertices)
		{
			return null;
		}

		private static Vector2 GetIntersectionPointCoordinates(Vector2 A1, Vector2 A2, Vector2 B1, Vector2 B2)
		{
			return default(Vector2);
		}

		private static float OutsideBounds(Vector2 P)
		{
			return 0f;
		}
	}
}
