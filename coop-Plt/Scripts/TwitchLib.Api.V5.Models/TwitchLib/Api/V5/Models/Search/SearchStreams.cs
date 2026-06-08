using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Streams;

namespace TwitchLib.Api.V5.Models.Search
{
	public class SearchStreams
	{
		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "streams")]
		public Stream[] Streams { get; protected set; }
	}
}
