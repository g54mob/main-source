using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class BadParameterException : Exception
	{
		public BadParameterException(string badParamData)
			: base(badParamData)
		{
		}
	}
}
