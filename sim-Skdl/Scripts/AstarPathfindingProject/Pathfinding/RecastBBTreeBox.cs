using UnityEngine;

namespace Pathfinding
{
	public class RecastBBTreeBox
	{
		public Rect rect;

		public RecastMeshObj mesh;

		public RecastBBTreeBox c1;

		public RecastBBTreeBox c2;

		public RecastBBTreeBox(RecastMeshObj mesh)
		{
		}

		public bool Contains(Vector3 p)
		{
			return false;
		}
	}
}
