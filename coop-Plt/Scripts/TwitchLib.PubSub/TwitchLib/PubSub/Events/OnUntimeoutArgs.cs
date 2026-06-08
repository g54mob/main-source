using System;

namespace TwitchLib.PubSub.Events
{
	public class OnUntimeoutArgs : EventArgs
	{
		public string UntimeoutedUser;

		public string UntimeoutedUserId;

		public string UntimeoutedBy;

		public string UntimeoutedByUserId;

		public string ChannelId;
	}
}
