using System;

namespace Coherence.Connection
{
	public class ConnectionException : Exception
	{
		public override string Message => null;

		public ConnectionException(string message)
		{
		}

		public ConnectionException(string message, Exception innerException)
		{
		}
	}
}
