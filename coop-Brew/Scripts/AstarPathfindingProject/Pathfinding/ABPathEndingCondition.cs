namespace Pathfinding
{
	public class ABPathEndingCondition : PathEndingCondition
	{
		protected ABPath abPath;

		public ABPathEndingCondition(ABPath p)
		{
		}

		public override bool TargetFound(GraphNode node, uint H, uint G)
		{
			return false;
		}
	}
}
