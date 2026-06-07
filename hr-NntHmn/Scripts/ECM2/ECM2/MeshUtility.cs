using System.Collections.Generic;
using UnityEngine;

namespace ECM2
{
	public static class MeshUtility
	{
		private const int kMaxVertices = 1024;

		private const int kMaxTriangles = 3072;

		private static readonly List<Vector3> _vertices;

		private static readonly List<ushort> _triangles16;

		private static readonly List<int> _triangles32;

		private static readonly List<ushort> _scratchBuffer16;

		private static readonly List<int> _scratchBuffer32;

		public static Vector3 FindMeshOpposingNormal(Mesh sharedMesh, ref RaycastHit inHit)
		{
			return default(Vector3);
		}

		public static void FlushBuffers()
		{
		}
	}
}
