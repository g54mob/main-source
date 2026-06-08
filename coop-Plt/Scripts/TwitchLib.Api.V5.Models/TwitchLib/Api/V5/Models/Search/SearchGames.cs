using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Games;

namespace TwitchLib.Api.V5.Models.Search
{
	public class SearchGames
	{
		[JsonProperty(PropertyName = "games")]
		public Game[] Games { get; protected set; }
	}
}
