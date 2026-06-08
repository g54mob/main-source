using System;

namespace TwitchLib.Client.Events
{
	public class OnJoinedChannelArgs : EventArgs
	{
		public string BotUsername;

		public string Channel;
	}
}
