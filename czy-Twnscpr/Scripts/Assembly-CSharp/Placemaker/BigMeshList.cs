using System.Collections.Generic;
using UnityEngine;

namespace Placemaker
{
	public struct BigMeshList
	{
		public List<Vector3> verts;

		public List<Vector3> normals;

		public List<Vector4> tangents;

		public List<Vector2> uvs;

		public List<int> tris;

		public static BigMeshList Get()
		{
			return default(BigMeshList);
		}

		public void ReturnToPool()
		{
		}

		public void Populate(MeshFilter mf)
		{
		}
	}
}
