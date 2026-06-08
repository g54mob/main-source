using System;

namespace TwitchLib.Client.Events
{
	public class OnConnectedArgs : EventArgs
	{
		public string BotUsername;

		public string AutoJoinChannel;
	}
}
