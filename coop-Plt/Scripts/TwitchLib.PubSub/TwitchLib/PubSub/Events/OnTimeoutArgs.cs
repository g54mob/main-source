using System;

namespace TwitchLib.PubSub.Events
{
	public class OnTimeoutArgs : EventArgs
	{
		public string TimedoutUserId;

		public string TimedoutUser;

		public TimeSpan TimeoutDuration;

		public string TimeoutReason;

		public string TimedoutBy;

		public string TimedoutById;

		public string ChannelId;
	}
}
