namespace sys.thread
{
	public sealed class NextEventTime_At : NextEventTime
	{
		public readonly double time;

		public NextEventTime_At(double time)
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
