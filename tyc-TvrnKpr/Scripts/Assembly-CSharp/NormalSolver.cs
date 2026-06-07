using UnityEngine;

public static class NormalSolver
{
	private struct VertexKey
	{
		private readonly long _x;

		private readonly long _y;

		private readonly long _z;

		private const int Tolerance = 100000;

		public VertexKey(Vector3 position)
		{
			_x = 0L;
			_y = 0L;
			_z = 0L;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}

	private sealed class VertexEntry
	{
		public int[] TriangleIndex;

		public int[] VertexIndex;

		private int _reserved;

		private int _count;

		public int Count => 0;

		public void Add(int vertIndex, int triIndex)
		{
		}
	}

	public static void RecalculateNormals(this Mesh mesh, float angle)
	{
	}
}
