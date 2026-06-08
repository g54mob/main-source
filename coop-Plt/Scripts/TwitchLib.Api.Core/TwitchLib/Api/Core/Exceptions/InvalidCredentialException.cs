using System;

namespace TwitchLib.Api.Core.Exceptions
{
	public class InvalidCredentialException : Exception
	{
		public InvalidCredentialException(string data)
			: base(data)
		{
		}
	}
}
