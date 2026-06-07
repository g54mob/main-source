using app.vis;

namespace test.auto
{
	public sealed class Action_Click : Action
	{
		public readonly int pointerId;

		public readonly PointData worldPos;

		public Action_Click(int pointerId, PointData worldPos)
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
