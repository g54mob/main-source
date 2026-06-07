using System;

namespace Pathfinding
{
	public class NNConstraint
	{
		public GraphMask graphMask;

		public bool constrainArea;

		public int area;

		public DistanceMetric distanceMetric;

		public bool constrainWalkability;

		public bool walkable;

		public bool constrainTags;

		public int tags;

		public bool constrainDistance;

		[Obsolete("Use distanceMetric = DistanceMetric.ClosestAsSeenFromAbove() instead")]
		public bool distanceXZ
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use NNConstraint.Walkable instead. It is equivalent, but the name is more descriptive")]
		public static NNConstraint Default => null;

		public static NNConstraint Walkable => null;

		public static NNConstraint None => null;

		public virtual bool SuitableGraph(int graphIndex, NavGraph graph)
		{
			return false;
		}

		public virtual bool Suitable(GraphNode node)
		{
			return false;
		}

		public void UseSettings(PathRequestSettings settings)
		{
		}
	}
}
