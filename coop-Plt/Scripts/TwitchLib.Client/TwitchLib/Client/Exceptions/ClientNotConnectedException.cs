using System;

namespace TwitchLib.Client.Exceptions
{
	public class ClientNotConnectedException : Exception
	{
		public ClientNotConnectedException(string description)
			: base(description)
		{
		}
	}
}
