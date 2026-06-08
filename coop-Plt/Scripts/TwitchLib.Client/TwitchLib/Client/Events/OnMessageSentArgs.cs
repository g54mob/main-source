using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnMessageSentArgs : EventArgs
	{
		public SentMessage SentMessage;
	}
}
