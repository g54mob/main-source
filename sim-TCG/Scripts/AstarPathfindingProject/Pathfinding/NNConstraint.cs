using System;

namespace Pathfinding
{
	public class NNConstraint
	{
		public GraphMask graphMask = -1;

		public bool constrainArea;

		public int area = -1;

		public DistanceMetric distanceMetric;

		public bool constrainWalkability = true;

		public bool walkable = true;

		public bool constrainTags = true;

		public int tags = -1;

		public bool constrainDistance = true;

		[Obsolete("Use distanceMetric = DistanceMetric.ClosestAsSeenFromAbove() instead")]
		public bool distanceXZ
		{
			get
			{
				if (distanceMetric.isProjectedDistance)
				{
					return distanceMetric.distanceScaleAlongProjectionDirection == 0f;
				}
				return false;
			}
			set
			{
				if (value)
				{
					distanceMetric = DistanceMetric.ClosestAsSeenFromAbove();
				}
				else
				{
					distanceMetric = DistanceMetric.Euclidean;
				}
			}
		}

		[Obsolete("Use NNConstraint.Walkable instead. It is equivalent, but the name is more descriptive")]
		public static NNConstraint Default => new NNConstraint();

		public static NNConstraint Walkable => new NNConstraint();

		public static NNConstraint None => new NNConstraint
		{
			constrainWalkability = false,
			constrainArea = false,
			constrainTags = false,
			constrainDistance = false,
			graphMask = -1
		};

		public virtual bool SuitableGraph(int graphIndex, NavGraph graph)
		{
			return graphMask.Contains(graphIndex);
		}

		public virtual bool Suitable(GraphNode node)
		{
			if (constrainWalkability && node.Walkable != walkable)
			{
				return false;
			}
			if (constrainArea && area >= 0 && node.Area != area)
			{
				return false;
			}
			if (constrainTags && ((tags >> (int)node.Tag) & 1) == 0)
			{
				return false;
			}
			return true;
		}
	}
}
