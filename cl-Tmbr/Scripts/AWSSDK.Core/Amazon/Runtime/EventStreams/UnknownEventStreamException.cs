using Amazon.Runtime.EventStreams.Internal;

namespace Amazon.Runtime.EventStreams
{
	public sealed class UnknownEventStreamException : EventStreamException
	{
		public string ExceptionType
		{
			get
			{
				return Data["ExceptionType"].ToString();
			}
			private set
			{
				Data["ExceptionType"] = value;
			}
		}

		public UnknownEventStreamException(string exceptionType)
		{
			ExceptionType = exceptionType;
		}
	}
}
