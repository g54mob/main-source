namespace Pathfinding
{
	public class EndingConditionProximity : ABPathEndingCondition
	{
		public float maxDistance;

		public EndingConditionProximity(ABPath p, float maxDistance)
			: base(null)
		{
		}

		public override bool TargetFound(PathNode node)
		{
			return false;
		}
	}
}
