using TwitchLib.PubSub.Models.Responses.Messages.Redemption;

namespace TwitchLib.PubSub.Events
{
	public class OnChannelPointsRewardRedeemedArgs
	{
		public string ChannelId { get; internal set; }

		public RewardRedeemed RewardRedeemed { get; internal set; }
	}
}
