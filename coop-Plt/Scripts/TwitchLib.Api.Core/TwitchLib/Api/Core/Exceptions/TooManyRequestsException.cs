using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public sealed class TooManyRequestsException : Exception
	{
		public TooManyRequestsException(string data, string resetTime)
			: base(data)
		{
			if (double.TryParse(resetTime, out var result))
			{
				Data.Add("Ratelimit-Reset", result);
			}
		}
	}
}
