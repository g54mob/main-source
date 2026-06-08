using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Games
{
	public class Game
	{
		[JsonProperty(PropertyName = "_id")]
		public int Id { get; protected set; }

		[JsonProperty(PropertyName = "box")]
		public GameBox Box { get; protected set; }

		[JsonProperty(PropertyName = "giantbomb_id")]
		public int GiantbombId { get; protected set; }

		[JsonProperty(PropertyName = "logo")]
		public GameLogo Logo { get; protected set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; protected set; }
	}
}
