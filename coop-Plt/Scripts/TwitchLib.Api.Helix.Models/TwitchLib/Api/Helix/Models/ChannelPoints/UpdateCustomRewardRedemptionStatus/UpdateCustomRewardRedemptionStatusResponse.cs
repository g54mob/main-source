using Newtonsoft.Json;

namespace TwitchLib.Api.Helix.Models.ChannelPoints.UpdateCustomRewardRedemptionStatus
{
	public class UpdateCustomRewardRedemptionStatusResponse
	{
		[JsonProperty(PropertyName = "data")]
		public RewardRedemption[] Data { get; protected set; }
	}
}
