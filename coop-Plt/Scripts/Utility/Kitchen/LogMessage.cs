namespace Kitchen
{
	public struct LogMessage
	{
		public string Source;

		public string Message;

		public static implicit operator string(LogMessage m)
		{
			return "(" + m.Source + ") " + m.Message;
		}

		public override string ToString()
		{
			return this;
		}
	}
}
