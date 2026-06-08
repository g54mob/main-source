using System;

namespace TwitchLib.PubSub.Events
{
	public class OnCustomRewardUpdatedArgs : EventArgs
	{
		public DateTime TimeStamp;

		public string ChannelId;

		public Guid RewardId;

		public string RewardTitle;

		public string RewardPrompt;

		public int RewardCost;
	}
}
