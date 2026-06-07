namespace test.auto
{
	public sealed class AutoStepBasic_WaitSeconds : AutoStepBasic
	{
		public readonly double seconds;

		public AutoStepBasic_WaitSeconds(double seconds)
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
