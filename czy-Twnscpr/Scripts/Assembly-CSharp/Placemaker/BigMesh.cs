using System.Collections.Generic;
using UnityEngine;

namespace Placemaker
{
	public class BigMesh : MonoBehaviour
	{
		public BigMeshGroup bigMeshGroup;

		public int createdCount;

		public bool dirty;

		public Mesh mesh;

		public List<ushort> availableIndexes;

		public List<int> availableTris;

		public List<Vector3> verts;

		public List<Vector3> normals;

		public List<Vector4> tangents;

		public List<Vector2> uvs;

		public List<int> tris;

		public int availableCount => 0;

		public int remainingCount => 0;

		public void Clear()
		{
		}

		public void SetDirty()
		{
		}
	}
}
