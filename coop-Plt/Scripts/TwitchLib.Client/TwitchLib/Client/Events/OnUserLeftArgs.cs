using System;

namespace TwitchLib.Client.Events
{
	public class OnUserLeftArgs : EventArgs
	{
		public string Username;

		public string Channel;
	}
}
