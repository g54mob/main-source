using System;

namespace Coherence.Connection
{
	public class ConnectionDeniedException : ConnectionException
	{
		public ConnectionCloseReason CloseReason { get; }

		public override string Message => null;

		public ConnectionDeniedException(ConnectionCloseReason closeReason)
			: base(null)
		{
		}

		public ConnectionDeniedException(ConnectionCloseReason closeReason, string message)
			: base(null)
		{
		}

		public ConnectionDeniedException(ConnectionCloseReason closeReason, string message, Exception innerException)
			: base(null)
		{
		}
	}
}
