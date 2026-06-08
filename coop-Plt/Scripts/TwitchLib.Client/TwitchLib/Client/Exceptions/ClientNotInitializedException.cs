using System;

namespace TwitchLib.Client.Exceptions
{
	public class ClientNotInitializedException : Exception
	{
		public ClientNotInitializedException(string description)
			: base(description)
		{
		}
	}
}
