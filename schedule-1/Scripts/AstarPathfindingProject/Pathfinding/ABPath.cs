using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class ABPath : Path
	{
		public GraphNode startNode;

		public GraphNode endNode;

		public Vector3 originalStartPoint;

		public Vector3 originalEndPoint;

		public Vector3 startPoint;

		public Vector3 endPoint;

		public Int3 startIntPoint;

		public bool calculatePartial;

		protected PathNode partialBestTarget;

		protected int[] endNodeCosts;

		private GridNode gridSpecialCaseNode;

		private static readonly NNConstraint NNConstraintNone;

		protected virtual bool hasEndPoint => false;

		public static ABPath Construct(Vector3 start, Vector3 end, OnPathDelegate callback = null)
		{
			return null;
		}

		protected void Setup(Vector3 start, Vector3 end, OnPathDelegate callbackDelegate)
		{
		}

		public static ABPath FakePath(List<Vector3> vectorPath, List<GraphNode> nodePath = null)
		{
			return null;
		}

		protected void UpdateStartEnd(Vector3 start, Vector3 end)
		{
		}

		public override uint GetConnectionSpecialCost(GraphNode a, GraphNode b, uint currentCost)
		{
			return 0u;
		}

		protected override void Reset()
		{
		}

		protected virtual bool EndPointGridGraphSpecialCase(GraphNode closestWalkableEndNode)
		{
			return false;
		}

		private void SetFlagOnSurroundingGridNodes(GridNode gridNode, int flag, bool flagState)
		{
		}

		protected override void Prepare()
		{
		}

		protected virtual void CompletePathIfStartIsValidTarget()
		{
		}

		protected override void Initialize()
		{
		}

		protected override void Cleanup()
		{
		}

		private void CompletePartial(PathNode node)
		{
		}

		private void CompleteWith(GraphNode node)
		{
		}

		protected override void CalculateStep(long targetTick)
		{
		}

		protected override string DebugString(PathLog logMode)
		{
			return null;
		}

		[Obsolete]
		public Vector3 GetMovementVector(Vector3 point)
		{
			return default(Vector3);
		}
	}
}
