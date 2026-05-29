namespace Pathfinding
{
	public class ABPathEndingCondition : PathEndingCondition
	{
		protected ABPath abPath;

		public ABPathEndingCondition(ABPath p)
		{
		}

		public override bool TargetFound(PathNode node)
		{
			return false;
		}
	}
}
