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

		bool Linecast(Vector3 start, Vector3 end, GraphNode startNodeHint, out GraphHitInfo hit, ref TraversalConstraint traversalConstraint, List<GraphNode> trace);

		bool Linecast(Vector3 start, Vector3 end, GraphNode startNodeHint, out GraphHitInfo hit, List<GraphNode> trace)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		bool Linecast(Vector3 start, Vector3 end, out GraphHitInfo hit)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		bool Linecast(Vector3 start, Vector3 end, out GraphHitInfo hit, ref TraversalConstraint traversalConstraint, List<GraphNode> trace = null);

		bool Linecast(Vector3 start, Vector3 end, out GraphHitInfo hit, List<GraphNode> trace)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		[Obsolete("Use the overload that takes a TraversalConstraint instead of a filter function")]
		bool Linecast(Vector3 start, Vector3 end, out GraphHitInfo hit, List<GraphNode> trace, Func<GraphNode, bool> filter)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		[Obsolete("Use the overload that takes a TraversalConstraint instead of a filter function")]
		bool Linecast(Vector3 start, Vector3 end, GraphNode startNodeHint, out GraphHitInfo hit, List<GraphNode> trace, Func<GraphNode, bool> filter)
		{
			hit = default(GraphHitInfo);
			return false;
		}
	}
}
