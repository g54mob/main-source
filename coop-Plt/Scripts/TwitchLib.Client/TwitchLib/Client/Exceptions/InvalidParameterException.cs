using System;

namespace TwitchLib.Client.Exceptions
{
	public class InvalidParameterException : Exception
	{
		public string Username { get; protected set; }

		public InvalidParameterException(string reasoning, string twitchUsername)
			: base(reasoning)
		{
			Username = twitchUsername;
		}
	}
}
