namespace test.auto
{
	public sealed class AutoStepBasic_WaitFrames : AutoStepBasic
	{
		public readonly int frameCount;

		public AutoStepBasic_WaitFrames(int frameCount)
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
