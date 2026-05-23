namespace sys.thread
{
	public sealed class NextEventTime_Never : NextEventTime
	{
		public NextEventTime_Never()
			: base(0)
		{
		}

		public override string getTag()
		{
			return null;
		}
	}
}
