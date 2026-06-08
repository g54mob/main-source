using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Games
{
	public class TopGames
	{
		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "top")]
		public TopGame[] Top { get; protected set; }
	}
}
