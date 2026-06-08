using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnMessageReceivedArgs : EventArgs
	{
		public ChatMessage ChatMessage;
	}
}
