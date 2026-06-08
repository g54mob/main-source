using System;

namespace TwitchLib.Client.Exceptions
{
	public class ErrorLoggingInException : Exception
	{
		public string Username { get; protected set; }

		public ErrorLoggingInException(string ircData, string twitchUsername)
			: base(ircData)
		{
			Username = twitchUsername;
		}
	}
}
