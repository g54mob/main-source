using System;

namespace Amazon.Runtime.EventStreams
{
	public sealed class EventStreamValidationException : Exception
	{
		public EventStreamValidationException()
		{
		}

		public EventStreamValidationException(string message)
			: base(message)
		{
		}

		public EventStreamValidationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
