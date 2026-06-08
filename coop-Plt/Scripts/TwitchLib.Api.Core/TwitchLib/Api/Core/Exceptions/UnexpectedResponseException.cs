using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class UnexpectedResponseException : Exception
	{
		public UnexpectedResponseException(string data)
			: base(data)
		{
		}
	}
}
