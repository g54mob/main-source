using System;

namespace TwitchLib.PubSub.Events
{
	public class OnUnbanArgs : EventArgs
	{
		public string UnbannedUser;

		public string UnbannedUserId;

		public string UnbannedBy;

		public string UnbannedByUserId;

		public string ChannelId;
	}
}
