namespace Pathfinding
{
	public class PathNNConstraint : NNConstraint
	{
		public new static PathNNConstraint Default
		{
			get
			{
				return new PathNNConstraint
				{
					constrainArea = true
				};
			}
		}

		public virtual void SetStart(GraphNode node)
		{
			if (node != null)
			{
				area = (int)node.Area;
			}
			else
			{
				constrainArea = false;
			}
		}
	}
}
