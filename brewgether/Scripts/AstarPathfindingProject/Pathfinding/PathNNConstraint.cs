namespace Pathfinding
{
	public class PathNNConstraint : NNConstraint
	{
		public new static PathNNConstraint Walkable => null;

		public virtual void SetStart(GraphNode node)
		{
		}
	}
}
