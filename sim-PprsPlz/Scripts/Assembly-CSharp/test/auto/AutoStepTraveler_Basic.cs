namespace test.auto
{
	public sealed class AutoStepTraveler_Basic : AutoStepTraveler
	{
		public readonly AutoStepBasic basicStep;

		public AutoStepTraveler_Basic(AutoStepBasic basicStep)
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
