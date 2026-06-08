using System;

namespace TwitchLib.Client.Events
{
	public class OnLeftChannelArgs : EventArgs
	{
		public string BotUsername;

		public string Channel;
	}
}
