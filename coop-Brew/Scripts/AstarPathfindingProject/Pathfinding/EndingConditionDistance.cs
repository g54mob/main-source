namespace Pathfinding
{
	public class EndingConditionDistance : PathEndingCondition
	{
		public int maxGScore;

		public EndingConditionDistance(Path p, int maxGScore)
		{
		}

		public override bool TargetFound(GraphNode node, uint H, uint G)
		{
			return false;
		}
	}
}
