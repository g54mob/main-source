using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Pathfinding
{
	public class MultiTargetPath : ABPath
	{
		public OnPathDelegate[] callbacks;

		public GraphNode[] targetNodes;

		protected int targetNodeCount;

		public bool[] targetsFound;

		public uint[] targetPathCosts;

		public Vector3[] targetPoints;

		public Vector3[] originalTargetPoints;

		public List<Vector3>[] vectorPaths;

		public List<GraphNode>[] nodePaths;

		public bool pathsForAll;

		public int chosenTarget;

		public bool inverted { get; protected set; }

		public override bool endPointKnownBeforeCalculation => false;

		public static MultiTargetPath Construct(Vector3[] startPoints, Vector3 target, OnPathDelegate[] callbackDelegates, OnPathDelegate callback = null)
		{
			return null;
		}

		public static MultiTargetPath Construct(Vector3 start, Vector3[] targets, OnPathDelegate[] callbackDelegates, OnPathDelegate callback = null)
		{
			return null;
		}

		protected void Setup(Vector3 start, Vector3[] targets, OnPathDelegate[] callbackDelegates, OnPathDelegate callback)
		{
		}

		protected override void Reset()
		{
		}

		protected override void OnEnterPool()
		{
		}

		private void ChooseShortestPath()
		{
		}

		private void SetPathParametersForReturn(int target)
		{
		}

		protected override void ReturnPath()
		{
		}

		protected void RebuildOpenList(ref SearchContext ctx)
		{
		}

		protected override void Prepare(ref SearchContext ctx)
		{
		}

		private void RecalculateHTarget(ref SearchContext ctx)
		{
		}

		protected override void Cleanup(ref SearchContext ctx)
		{
		}

		protected override void OnHeapExhausted(ref SearchContext ctx)
		{
		}

		protected override void OnFoundEndNode(ref SearchContext ctx, uint pathNode, uint hScore, uint gScore)
		{
		}

		protected override void Trace(ref SearchContext ctx, uint pathNodeIndex)
		{
		}

		protected override void DebugString(StringBuilder text, PathLog logMode)
		{
		}
	}
}
