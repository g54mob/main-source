namespace Pathfinding
{
	public class EndingConditionProximity : ABPathEndingCondition
	{
		public float maxDistance;

		public EndingConditionProximity(ABPath p, float maxDistance)
			: base(null)
		{
		}

		public override bool TargetFound(GraphNode node, uint H, uint G)
		{
			return false;
		}
	}
}
