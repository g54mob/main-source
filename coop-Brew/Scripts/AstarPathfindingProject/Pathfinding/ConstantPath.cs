using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class ConstantPath : Path
	{
		public GraphNode startNode;

		public Vector3 startPoint;

		public Vector3 originalStartPoint;

		public List<GraphNode> allNodes;

		public PathEndingCondition endingCondition;

		public static ConstantPath Construct(Vector3 start, int maxGScore, OnPathDelegate callback = null)
		{
			return null;
		}

		protected void Setup(Vector3 start, int maxGScore, OnPathDelegate callback)
		{
		}

		protected override void OnEnterPool()
		{
		}

		protected override void Reset()
		{
		}

		protected override void Prepare()
		{
		}

		protected override void OnHeapExhausted()
		{
		}

		protected override void OnFoundEndNode(uint pathNode, uint hScore, uint gScore)
		{
		}

		public override void OnVisitNode(uint pathNode, uint hScore, uint gScore)
		{
		}
	}
}
