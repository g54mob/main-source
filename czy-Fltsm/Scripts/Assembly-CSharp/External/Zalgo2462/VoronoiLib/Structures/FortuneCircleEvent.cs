using System;

namespace External.Zalgo2462.VoronoiLib.Structures
{
	internal class FortuneCircleEvent : FortuneEvent, IComparable<FortuneEvent>
	{
		internal VPoint Lowest { get; }

		internal double YCenter { get; }

		internal RBTreeNode<BeachSection> ToDelete { get; }

		public double X => Lowest.X;

		public double Y => Lowest.Y;

		internal FortuneCircleEvent(VPoint lowest, double yCenter, RBTreeNode<BeachSection> toDelete)
		{
			Lowest = lowest;
			YCenter = yCenter;
			ToDelete = toDelete;
		}

		public int CompareTo(FortuneEvent other)
		{
			int num = Y.CompareTo(other.Y);
			if (num != 0)
			{
				return num;
			}
			return X.CompareTo(other.X);
		}
	}
}
