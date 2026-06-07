using play.day;

namespace test.auto
{
	public sealed class AutoStepTraveler_ClickEngineAction : AutoStepTraveler
	{
		public readonly EngineAction engineAction;

		public AutoStepTraveler_ClickEngineAction(EngineAction engineAction)
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
