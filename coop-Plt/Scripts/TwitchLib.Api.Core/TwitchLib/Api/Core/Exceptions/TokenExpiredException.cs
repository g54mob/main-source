using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class TokenExpiredException : Exception
	{
		public TokenExpiredException(string data)
			: base(data)
		{
		}
	}
}
