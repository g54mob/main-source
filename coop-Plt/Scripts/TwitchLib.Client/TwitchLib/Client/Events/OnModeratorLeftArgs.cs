using System;

namespace TwitchLib.Client.Events
{
	public class OnModeratorLeftArgs : EventArgs
	{
		public string Username;

		public string Channel;
	}
}
