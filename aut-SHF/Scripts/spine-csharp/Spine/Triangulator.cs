namespace Spine
{
	public class Triangulator
	{
		private readonly ExposedList<ExposedList<float>> convexPolygons;

		private readonly ExposedList<ExposedList<int>> convexPolygonsIndices;

		private readonly ExposedList<int> indicesArray;

		private readonly ExposedList<bool> isConcaveArray;

		private readonly ExposedList<int> triangles;

		private readonly Pool<ExposedList<float>> polygonPool;

		private readonly Pool<ExposedList<int>> polygonIndicesPool;

		public ExposedList<int> Triangulate(ExposedList<float> verticesArray)
		{
			return null;
		}

		public ExposedList<ExposedList<float>> Decompose(ExposedList<float> verticesArray, ExposedList<int> triangles)
		{
			return null;
		}

		private static bool IsConcave(int index, int vertexCount, float[] vertices, int[] indices)
		{
			return false;
		}

		private static bool PositiveArea(float p1x, float p1y, float p2x, float p2y, float p3x, float p3y)
		{
			return false;
		}

		private static int Winding(float p1x, float p1y, float p2x, float p2y, float p3x, float p3y)
		{
			return 0;
		}
	}
}
