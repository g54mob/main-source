using System;

namespace Pathfinding
{
	public class ABPathEndingCondition : PathEndingCondition
	{
		protected ABPath abPath;

		public ABPathEndingCondition(ABPath p)
		{
			if (p == null)
			{
				throw new ArgumentNullException("p");
			}
			abPath = p;
			path = p;
		}

		public override bool TargetFound(GraphNode node, uint H, uint G)
		{
			return node == abPath.endNode;
		}
	}
}
