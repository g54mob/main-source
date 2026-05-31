namespace Pathfinding
{
	public class PathNNConstraint : NNConstraint
	{
		public new static PathNNConstraint Default => null;

		public virtual void SetStart(GraphNode node)
		{
		}
	}
}
