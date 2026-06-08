using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class BadScopeException : Exception
	{
		public BadScopeException(string data)
			: base(data)
		{
		}
	}
}
