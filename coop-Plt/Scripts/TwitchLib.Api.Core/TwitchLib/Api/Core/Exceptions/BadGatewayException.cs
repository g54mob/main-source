using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class BadGatewayException : Exception
	{
		public BadGatewayException(string data)
			: base(data)
		{
		}
	}
}
