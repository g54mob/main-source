namespace test.auto
{
	public sealed class AutoStepPlayer_Basic : AutoStepPlayer
	{
		public readonly AutoStepBasic basicStep;

		public AutoStepPlayer_Basic(AutoStepBasic basicStep)
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
