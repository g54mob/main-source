namespace Pathfinding
{
	public class EndingConditionDistance : PathEndingCondition
	{
		public int maxGScore;

		public EndingConditionDistance(Path p, int maxGScore)
		{
		}

		public override bool TargetFound(PathNode node)
		{
			return false;
		}
	}
}
