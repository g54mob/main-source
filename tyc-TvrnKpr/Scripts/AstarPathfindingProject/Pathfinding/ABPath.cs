using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Pathfinding
{
	public class ABPath : Path
	{
		public Vector3 originalStartPoint;

		public Vector3 originalEndPoint;

		public Vector3 startPoint;

		public Vector3 endPoint;

		public uint cost;

		public bool calculatePartial;

		protected uint partialBestTargetPathNodeIndex;

		protected uint partialBestTargetHScore;

		protected uint partialBestTargetGScore;

		public PathEndingCondition endingCondition;

		public GraphNode startNode => null;

		public GraphNode endNode => null;

		protected virtual bool hasEndPoint => false;

		public virtual bool endPointKnownBeforeCalculation => false;

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

		protected override void Reset()
		{
		}

		protected virtual bool EndPointGridGraphSpecialCase(ref SearchContext ctx, GraphNode closestWalkableEndNode, Vector3 originalEndPoint, int targetIndex)
		{
			return false;
		}

		private void AddEndpointsForSurroundingGridNodes(ref SearchContext ctx, GridNode gridNode, Vector3 desiredPoint, int targetIndex)
		{
		}

		protected override void Prepare(ref SearchContext ctx)
		{
		}

		protected void FindStartAndEndNodes(ref SearchContext ctx, ref NearestNodeConstraint constraint)
		{
		}

		private void CompletePartial(ref SearchContext ctx)
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

		protected override void DebugString(StringBuilder builder, PathLog logMode)
		{
		}
	}
}
