using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class RecastBBTree
	{
		private RecastBBTreeBox root;

		public void QueryInBounds(Rect bounds, List<RecastMeshObj> buffer)
		{
		}

		private void QueryBoxInBounds(RecastBBTreeBox box, Rect bounds, List<RecastMeshObj> boxes)
		{
		}

		public bool Remove(RecastMeshObj mesh)
		{
			return false;
		}

		private RecastBBTreeBox RemoveBox(RecastBBTreeBox c, RecastMeshObj mesh, Rect bounds, ref bool found)
		{
			return null;
		}

		public void Insert(RecastMeshObj mesh)
		{
		}

		private static bool RectIntersectsRect(Rect r, Rect r2)
		{
			return false;
		}

		private static float ExpansionRequired(Rect r, Rect r2)
		{
			return 0f;
		}

		private static Rect ExpandToContain(Rect r, Rect r2)
		{
			return default(Rect);
		}

		private static float RectArea(Rect r)
		{
			return 0f;
		}
	}
}
