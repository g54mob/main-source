using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class FloodPath : Path
	{
		public Vector3 originalStartPoint;

		public Vector3 startPoint;

		public GraphNode startNode;

		public bool saveParents;

		protected Dictionary<uint, uint> parents;

		private uint validationHash;

		public const uint TemporaryNodeBit = 2147483648u;

		public bool HasPathTo(GraphNode node)
		{
			return false;
		}

		internal bool IsValid(GlobalNodeStorage nodeStorage)
		{
			return false;
		}

		public uint GetParent(uint node)
		{
			return 0u;
		}

		public static FloodPath Construct(Vector3 start, OnPathDelegate callback = null)
		{
			return null;
		}

		public static FloodPath Construct(GraphNode start, OnPathDelegate callback = null)
		{
			return null;
		}

		protected void Setup(Vector3 start, OnPathDelegate callback)
		{
		}

		protected void Setup(GraphNode start, OnPathDelegate callback)
		{
		}

		protected override void Reset()
		{
		}

		protected override void Prepare(ref SearchContext ctx)
		{
		}

		protected override void OnHeapExhausted(ref SearchContext ctx)
		{
		}

		protected override void OnFoundEndNode(ref SearchContext ctx, uint pathNode, uint hScore, uint gScore)
		{
		}

		public override void OnVisitNode(ref SearchContext ctx, uint pathNode, uint hScore, uint gScore)
		{
		}
	}
}
