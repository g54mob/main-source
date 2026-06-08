using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Games
{
	public class TopGame
	{
		[JsonProperty(PropertyName = "channels")]
		public int Channels { get; protected set; }

		[JsonProperty(PropertyName = "viewers")]
		public int Viewers { get; protected set; }

		[JsonProperty(PropertyName = "game")]
		public Game Game { get; protected set; }
	}
}
