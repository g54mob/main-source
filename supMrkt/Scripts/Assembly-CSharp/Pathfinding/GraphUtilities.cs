using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public static class GraphUtilities
	{
		public static List<Vector3> GetContours(NavGraph graph)
		{
			return null;
		}

		public static void GetContours(INavmesh navmesh, Action<List<Int3>, bool> results)
		{
		}

		public static void GetContours(GridGraph grid, Action<Vector3[]> callback, float yMergeThreshold, GridNodeBase[] nodes = null)
		{
		}
	}
}
