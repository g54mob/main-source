using UnityEngine;

namespace Pathfinding.Voxels
{
	public class RasterizationMesh
	{
		public MeshFilter original;

		public int area;

		public Vector3[] vertices;

		public int[] triangles;

		public int numVertices;

		public int numTriangles;

		public Bounds bounds;

		public Matrix4x4 matrix;

		public bool pool;

		public RasterizationMesh()
		{
		}

		public RasterizationMesh(Vector3[] vertices, int[] triangles, Bounds bounds)
		{
		}

		public RasterizationMesh(Vector3[] vertices, int[] triangles, Bounds bounds, Matrix4x4 matrix)
		{
		}

		public void RecalculateBounds()
		{
		}

		public void Pool()
		{
		}
	}
}
