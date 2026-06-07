using System;

namespace Coherence.Connection
{
	public class ConnectionClosedException : ConnectionException
	{
		public ConnectionClosedException(string message, Exception innerException)
			: base(null)
		{
		}
	}
}
