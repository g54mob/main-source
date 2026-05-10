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

		public override bool FloodingPath => false;

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

		protected override void Initialize()
		{
		}

		protected override void Cleanup()
		{
		}

		protected override void CalculateStep(long targetTick)
		{
		}
	}
}
