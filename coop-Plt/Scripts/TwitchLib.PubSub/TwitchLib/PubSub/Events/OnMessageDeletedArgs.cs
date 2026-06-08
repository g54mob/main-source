using System;

namespace TwitchLib.PubSub.Events
{
	public class OnMessageDeletedArgs : EventArgs
	{
		public string TargetUser;

		public string TargetUserId;

		public string DeletedBy;

		public string DeletedByUserId;

		public string Message;

		public string MessageId;

		public string ChannelId;
	}
}
