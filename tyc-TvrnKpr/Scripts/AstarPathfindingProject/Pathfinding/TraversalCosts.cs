using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public struct TraversalCosts
	{
		public ITraversalProvider traversalProvider;

		[SerializeField]
		private uint[] tagEntryCostsInternal;

		[SerializeField]
		private float[] tagCostMultipliersInternal;

		public uint[] tagEntryCosts
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float[] tagCostMultipliers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool hasCosts => false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use GetTraversalCostMultiplier instead")]
		public uint GetTraversalCost(GraphNode node)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetTraversalCostMultiplier(GraphNode node)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint GetConnectionCost(GraphNode from, GraphNode to)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetDefaultTraversalCostMultiplier(GraphNode node)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint GetDefaultConnectionCost(GraphNode from, GraphNode to)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint GetTagEntryCost(uint tag)
		{
			return 0u;
		}
	}
}
