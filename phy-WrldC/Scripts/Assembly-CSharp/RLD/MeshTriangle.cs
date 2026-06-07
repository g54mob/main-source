using UnityEngine;

namespace RLD
{
	public class MeshTriangle
	{
		private Vector3[] _vertices;

		private Vector3 _normal;

		private int _triangleIndex;

		private int[] _vertIndices;

		public int TriangleIndex => _triangleIndex;

		public Vector3[] Vertices => _vertices.Clone() as Vector3[];

		public Vector3 Vertex0 => _vertices[0];

		public Vector3 Vertex1 => _vertices[1];

		public Vector3 Vertex2 => _vertices[2];

		public Vector3 Normal => _normal;

		public int[] VertIndices => _vertIndices.Clone() as int[];

		public int VertIndex0 => _vertIndices[0];

		public int VertIndex1 => _vertIndices[1];

		public int VertIndex2 => _vertIndices[2];

		public MeshTriangle(Vector3[] vertices, int triangleIndex, int vertIndex0, int vertIndex1, int vertIndex2)
		{
			_vertices = vertices.Clone() as Vector3[];
			_triangleIndex = triangleIndex;
			_vertIndices = new int[3];
			_vertIndices[0] = vertIndex0;
			_vertIndices[1] = vertIndex1;
			_vertIndices[2] = vertIndex2;
			_normal = Vector3.Cross(_vertices[1] - _vertices[0], _vertices[2] - _vertices[0]).normalized;
		}

		public int GetVertIndex(int arrayIndex)
		{
			return _vertIndices[arrayIndex];
		}
	}
}
