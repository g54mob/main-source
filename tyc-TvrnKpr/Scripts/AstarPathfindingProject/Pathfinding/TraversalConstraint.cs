using System;
using System.Runtime.CompilerServices;

namespace Pathfinding
{
	public struct TraversalConstraint
	{
		internal enum FilterType
		{
			None = 0,
			TraversalProvider = 1,
			Func = 2
		}

		internal object filterObj;

		public int tags;

		public GraphMask graphMask;

		internal FilterType filterType;

		public static readonly TraversalConstraint None;

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

		public bool filterDiagonalGridConnections => false;

		public TraversalConstraint(Func<GraphNode, bool> filter)
		{
			filterObj = null;
			tags = 0;
			graphMask = default(GraphMask);
			filterType = default(FilterType);
		}

		public TraversalConstraint(ITraversalProvider traversalProvider)
		{
			filterObj = null;
			tags = 0;
			graphMask = default(GraphMask);
			filterType = default(FilterType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool CanTraverse(GraphNode node)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool CanTraverse(GraphNode from, GraphNode to)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool CanTraverseSkipUserFilter(GraphNode node)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NearestNodeConstraint ToNearestNodeConstraint()
		{
			return default(NearestNodeConstraint);
		}
	}
}
