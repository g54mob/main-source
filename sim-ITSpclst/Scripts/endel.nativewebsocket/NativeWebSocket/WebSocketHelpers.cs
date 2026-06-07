using System;

namespace NativeWebSocket
{
	public static class WebSocketHelpers
	{
		public static WebSocketCloseCode ParseCloseCodeEnum(int closeCode)
		{
			return default(WebSocketCloseCode);
		}

		public static WebSocketException GetErrorMessageFromCode(int errorCode, Exception inner)
		{
			return null;
		}
	}
}
