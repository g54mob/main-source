using app.ent;
using app.vis;

namespace test.auto
{
	public sealed class Action_Swipe : Action
	{
		public readonly int pointerId;

		public readonly PointData startWorldPos;

		public readonly SwipeDir swipeDir;

		public Action_Swipe(int pointerId, PointData startWorldPos, SwipeDir swipeDir)
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
