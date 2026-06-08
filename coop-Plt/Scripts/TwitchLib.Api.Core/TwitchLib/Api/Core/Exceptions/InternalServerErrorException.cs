using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class InternalServerErrorException : Exception
	{
		public InternalServerErrorException(string data)
			: base(data)
		{
		}
	}
}
