using System;

namespace TwitchLib.Client.Exceptions
{
	public class BadStateException : Exception
	{
		public BadStateException(string details)
			: base(details)
		{
		}
	}
}
