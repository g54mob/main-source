using Amazon.Runtime.EventStreams.Internal;

namespace Amazon.Runtime.EventStreams
{
	public sealed class EventStreamErrorCodeException : EventStreamException
	{
		public int ErrorCode
		{
			get
			{
				return (int)Data["ErrorCode"];
			}
			private set
			{
				Data["ErrorCode"] = value;
			}
		}

		public EventStreamErrorCodeException(int errorCode)
			: this(errorCode, null)
		{
		}

		public EventStreamErrorCodeException(int errorCode, string message)
			: base(message)
		{
			ErrorCode = errorCode;
		}
	}
}
