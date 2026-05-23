namespace Pathfinding
{
	public class NNConstraintWithTraversalProvider : NNConstraint
	{
		public ITraversalProvider traversalProvider;

		public NNConstraint baseConstraint;

		public Path path;

		public bool isSet => traversalProvider != null;

		public void Reset()
		{
			traversalProvider = null;
			baseConstraint = null;
			path = null;
		}

		public void Set(Path path, NNConstraint constraint, ITraversalProvider traversalProvider)
		{
			this.path = path;
			this.traversalProvider = traversalProvider;
			baseConstraint = constraint;
			graphMask = constraint.graphMask;
			constrainArea = constraint.constrainArea;
			area = constraint.area;
			distanceMetric = constraint.distanceMetric;
			constrainWalkability = constraint.constrainWalkability;
			walkable = constraint.walkable;
			constrainTags = constraint.constrainTags;
			tags = constraint.tags;
			constrainDistance = constraint.constrainDistance;
		}

		public override bool SuitableGraph(int graphIndex, NavGraph graph)
		{
			return baseConstraint.SuitableGraph(graphIndex, graph);
		}

		public override bool Suitable(GraphNode node)
		{
			if (baseConstraint.Suitable(node))
			{
				return traversalProvider.CanTraverse(path, node);
			}
			return false;
		}
	}
}
