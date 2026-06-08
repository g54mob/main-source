using System;

namespace TwitchLib.Client.Events
{
	public class OnMessageClearedArgs : EventArgs
	{
		public string Channel;

		public string Message;

		public string TargetMessageId;

		public string TmiSentTs;
	}
}
