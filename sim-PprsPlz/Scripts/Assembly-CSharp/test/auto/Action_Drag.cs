using app.vis;

namespace test.auto
{
	public sealed class Action_Drag : Action
	{
		public readonly int pointerId;

		public readonly PointData startWorldPos;

		public readonly PointData endWorldPos;

		public readonly object endHoldFrameCount;

		public Action_Drag(int pointerId, PointData startWorldPos, PointData endWorldPos, object endHoldFrameCount)
			: base(0)
		{
		}

		public override Array getParams()
		{
			return null;
		}

		public override string getTag()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override string toString()
		{
			return null;
		}
	}
}
