using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class BadResourceException : Exception
	{
		public BadResourceException(string apiData)
			: base(apiData)
		{
		}
	}
}
