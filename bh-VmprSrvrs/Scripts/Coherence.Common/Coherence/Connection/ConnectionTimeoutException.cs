using System;

namespace Coherence.Connection
{
	public class ConnectionTimeoutException : ConnectionException
	{
		public TimeSpan After { get; }

		public override string Message => null;

		public ConnectionTimeoutException(TimeSpan after)
			: base(null)
		{
		}

		public ConnectionTimeoutException(TimeSpan after, string message)
			: base(null)
		{
		}

		public ConnectionTimeoutException(TimeSpan after, string message, Exception innerException)
			: base(null)
		{
		}
	}
}
