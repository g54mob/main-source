namespace Pathfinding
{
	public class FloodPathConstraint : NNConstraint
	{
		private readonly FloodPath path;

		public FloodPathConstraint(FloodPath path)
		{
		}

		public override bool Suitable(GraphNode node)
		{
			return false;
		}
	}
}
