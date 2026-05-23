namespace sys.thread
{
	public sealed class NextEventTime_Now : NextEventTime
	{
		public NextEventTime_Now()
			: base(0)
		{
		}

		public override string getTag()
		{
			return null;
		}
	}
}
