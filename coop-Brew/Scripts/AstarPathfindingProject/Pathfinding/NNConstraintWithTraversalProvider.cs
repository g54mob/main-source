namespace Pathfinding
{
	public class NNConstraintWithTraversalProvider : NNConstraint
	{
		public ITraversalProvider traversalProvider;

		public NNConstraint baseConstraint;

		public Path path;

		public bool isSet => false;

		public void Reset()
		{
		}

		public void Set(Path path, NNConstraint constraint, ITraversalProvider traversalProvider)
		{
		}

		public override bool SuitableGraph(int graphIndex, NavGraph graph)
		{
			return false;
		}

		public override bool Suitable(GraphNode node)
		{
			return false;
		}
	}
}
