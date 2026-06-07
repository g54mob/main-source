namespace Epic.OnlineServices.Logging
{
	public class LogMessage : ISettable
	{
		public string Category { get; private set; }

		public string Message { get; private set; }

		public LogLevel Level { get; private set; }

		internal void Set(LogMessageInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
