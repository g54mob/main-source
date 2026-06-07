using System;

namespace MessagePipe
{
	public class RemoteRequestException : Exception
	{
		public RemoteRequestException(string message)
			: base(message)
		{
		}
	}
}
