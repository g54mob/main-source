namespace app
{
	public sealed class ThreadMessage_Quit : ThreadMessage
	{
		public ThreadMessage_Quit()
			: base(0)
		{
		}

		public override string getTag()
		{
			return null;
		}
	}
}
