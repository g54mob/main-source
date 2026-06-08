using System;

namespace TwitchLib.Client.Events
{
	public class OnUserJoinedArgs : EventArgs
	{
		public string Username;

		public string Channel;
	}
}
