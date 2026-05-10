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

		protected Dictionary<GraphNode, GraphNode> parents;

		public override bool FloodingPath => false;

		public bool HasPathTo(GraphNode node)
		{
			return false;
		}

		public GraphNode GetParent(GraphNode node)
		{
			return null;
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

		protected override void Prepare()
		{
		}

		protected override void Initialize()
		{
		}

		protected override void CalculateStep(long targetTick)
		{
		}
	}
}
