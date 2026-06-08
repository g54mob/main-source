using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Channels;

namespace TwitchLib.Api.V5.Models.Search
{
	public class SearchChannels
	{
		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "channels")]
		public Channel[] Channels { get; protected set; }
	}
}
