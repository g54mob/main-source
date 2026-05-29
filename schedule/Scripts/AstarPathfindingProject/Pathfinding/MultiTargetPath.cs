using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class MultiTargetPath : ABPath
	{
		public enum HeuristicMode
		{
			None = 0,
			Average = 1,
			MovingAverage = 2,
			Midpoint = 3,
			MovingMidpoint = 4,
			Sequential = 5
		}

		public OnPathDelegate[] callbacks;

		public GraphNode[] targetNodes;

		protected int targetNodeCount;

		public bool[] targetsFound;

		public Vector3[] targetPoints;

		public Vector3[] originalTargetPoints;

		public List<Vector3>[] vectorPaths;

		public List<GraphNode>[] nodePaths;

		public bool pathsForAll;

		public int chosenTarget;

		private int sequentialTarget;

		public HeuristicMode heuristicMode;

		public bool inverted { get; protected set; }

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

		protected void FoundTarget(PathNode nodeR, int i)
		{
		}

		protected void RebuildOpenList()
		{
		}

		protected override void Prepare()
		{
		}

		private void RecalculateHTarget(bool firstTime)
		{
		}

		protected override void Initialize()
		{
		}

		protected override void Cleanup()
		{
		}

		private void ResetFlags()
		{
		}

		protected override void CalculateStep(long targetTick)
		{
		}

		protected override void Trace(PathNode node)
		{
		}

		protected override string DebugString(PathLog logMode)
		{
			return null;
		}
	}
}
