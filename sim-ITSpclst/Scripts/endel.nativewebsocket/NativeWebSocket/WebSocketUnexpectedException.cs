using System;

namespace NativeWebSocket
{
	public class WebSocketUnexpectedException : WebSocketException
	{
		public WebSocketUnexpectedException()
		{
		}

		public WebSocketUnexpectedException(string message)
		{
		}

		public WebSocketUnexpectedException(string message, Exception inner)
		{
		}
	}
}
