using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class GatewayTimeoutException : Exception
	{
		public GatewayTimeoutException(string data)
			: base(data)
		{
		}
	}
}
