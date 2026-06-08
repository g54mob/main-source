using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Teams;

namespace TwitchLib.Api.V5.Models.Channels
{
	public class ChannelTeams
	{
		[JsonProperty(PropertyName = "teams")]
		public Team[] Teams { get; protected set; }
	}
}
