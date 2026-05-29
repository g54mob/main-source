using UnityEngine;

namespace Pathfinding
{
	public class EndingConditionProximity : ABPathEndingCondition
	{
		public float maxDistance = 10f;

		public EndingConditionProximity(ABPath p, float maxDistance)
			: base(p)
		{
			this.maxDistance = maxDistance;
		}

		public override bool TargetFound(GraphNode node, uint H, uint G)
		{
			return ((Vector3)node.position - abPath.originalEndPoint).sqrMagnitude <= maxDistance * maxDistance;
		}
	}
}
