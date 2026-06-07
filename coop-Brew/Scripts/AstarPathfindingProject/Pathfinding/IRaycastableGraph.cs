using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public interface IRaycastableGraph
	{
		bool Linecast(Vector3 start, Vector3 end);

		[Obsolete]
		bool Linecast(Vector3 start, Vector3 end, GraphNode startNodeHint);

		[Obsolete]
		bool Linecast(Vector3 start, Vector3 end, GraphNode startNodeHint, out GraphHitInfo hit);

		bool Linecast(Vector3 start, Vector3 end, GraphNode startNodeHint, out GraphHitInfo hit, List<GraphNode> trace, Func<GraphNode, bool> filter = null);

		bool Linecast(Vector3 start, Vector3 end, out GraphHitInfo hit, List<GraphNode> trace = null, Func<GraphNode, bool> filter = null);
	}
}
