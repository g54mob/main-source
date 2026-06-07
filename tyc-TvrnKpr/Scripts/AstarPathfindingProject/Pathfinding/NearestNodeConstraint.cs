using System;
using System.Runtime.CompilerServices;

namespace Pathfinding
{
	public struct NearestNodeConstraint
	{
		public enum WalkabilityConstraint : byte
		{
			Walkable = 0,
			Unwalkable = 1,
			DontCare = 2
		}

		public DistanceMetric distanceMetric;

		public int area;

		public float maxDistanceSqr;

		internal TraversalConstraint traversal;

		public WalkabilityConstraint walkable;

		public static readonly NearestNodeConstraint Walkable;

		public static readonly NearestNodeConstraint None;

		public int tags
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public GraphMask graphMask
		{
			get
			{
				return default(GraphMask);
			}
			set
			{
			}
		}

		public Func<GraphNode, bool> filter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ITraversalProvider traversalProvider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool allNodesAreSuitable => false;

		public float? maxDistance
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal float maxDistanceSqrOrDefault(AstarPath astar)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Suitable(GraphNode node)
		{
			return false;
		}
	}
}
