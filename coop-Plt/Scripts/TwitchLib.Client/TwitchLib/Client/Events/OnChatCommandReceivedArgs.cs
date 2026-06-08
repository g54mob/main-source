using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnChatCommandReceivedArgs : EventArgs
	{
		public ChatCommand Command;
	}
}
