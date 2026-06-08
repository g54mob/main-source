using Newtonsoft.Json;
using TwitchLib.Api.Core.Interfaces;

namespace TwitchLib.Api.V5.Models.Channels
{
	public class ChannelFollowers : IFollows
	{
		[JsonProperty(PropertyName = "_cursor")]
		public string Cursor { get; protected set; }

		[JsonProperty(PropertyName = "_total")]
		public int Total { get; protected set; }

		[JsonProperty(PropertyName = "follows")]
		public IFollow[] Follows { get; protected set; }

		public ChannelFollowers(ChannelFollow[] follows)
		{
			Follows = follows;
		}
	}
}
