using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string apiData)
			: base(apiData)
		{
		}
	}
}
