using System.Collections.Generic;
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

		protected void RebuildOpenList()
		{
		}

		protected override void Prepare()
		{
		}

		private void RecalculateHTarget()
		{
		}

		protected override void Cleanup()
		{
		}

		protected override void OnHeapExhausted()
		{
		}

		protected override void OnFoundEndNode(uint pathNode, uint hScore, uint gScore)
		{
		}

		protected override void Trace(uint pathNodeIndex)
		{
		}

		protected override string DebugString(PathLog logMode)
		{
			return null;
		}
	}
}
