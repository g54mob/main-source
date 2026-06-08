using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class BadTokenException : Exception
	{
		public BadTokenException(string data)
			: base(data)
		{
		}
	}
}
