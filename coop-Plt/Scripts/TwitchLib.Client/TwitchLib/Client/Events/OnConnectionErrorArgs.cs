using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnConnectionErrorArgs : EventArgs
	{
		public ErrorEvent Error;

		public string BotUsername;
	}
}
