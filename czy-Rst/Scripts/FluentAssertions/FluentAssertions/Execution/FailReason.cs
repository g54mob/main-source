namespace FluentAssertions.Execution
{
	public class FailReason
	{
		public string Message { get; }

		public object[] Args { get; }

		public FailReason(string message, params object[] args)
		{
			Message = message;
			Args = args;
		}
	}
}
