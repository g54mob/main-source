using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Teams
{
	public class AllTeams
	{
		[JsonProperty(PropertyName = "teams")]
		public Team[] Teams { get; protected set; }
	}
}
