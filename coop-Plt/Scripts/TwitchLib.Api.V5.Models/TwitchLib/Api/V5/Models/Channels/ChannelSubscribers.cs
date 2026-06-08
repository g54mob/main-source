using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Subscriptions;

namespace TwitchLib.Api.V5.Models.Channels
{
	public class ChannelSubscribers
	{
		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "subscriptions")]
		public Subscription[] Subscriptions { get; protected set; }
	}
}
