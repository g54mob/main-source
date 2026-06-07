using System;

namespace LitMotion
{
	internal struct MotionSequenceItem : IComparable<MotionSequenceItem>
	{
		public double Position;

		public MotionHandle Handle;

		public MotionSequenceItem(double position, MotionHandle handle)
		{
			Position = position;
			Handle = handle;
		}

		public int CompareTo(MotionSequenceItem other)
		{
			return Position.CompareTo(other.Position);
		}
	}
}
