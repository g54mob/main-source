using System;

namespace TwitchLib.Client.Events
{
	public class OnModeratorJoinedArgs : EventArgs
	{
		public string Username;

		public string Channel;
	}
}
