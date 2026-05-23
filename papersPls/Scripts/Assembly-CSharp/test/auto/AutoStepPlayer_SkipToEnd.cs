namespace test.auto
{
	public sealed class AutoStepPlayer_SkipToEnd : AutoStepPlayer
	{
		public readonly string endId;

		public AutoStepPlayer_SkipToEnd(string endId)
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
