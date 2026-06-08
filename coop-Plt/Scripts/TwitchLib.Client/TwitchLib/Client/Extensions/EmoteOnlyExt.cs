using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class EmoteOnlyExt
	{
		public static void EmoteOnlyOn(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".emoteonly");
		}

		public static void EmoteOnlyOn(this ITwitchClient client, string channel)
		{
			client.SendMessage(channel, ".emoteonly");
		}

		public static void EmoteOnlyOff(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".emoteonlyoff");
		}

		public static void EmoteOnlyOff(this ITwitchClient client, string channel)
		{
			client.SendMessage(channel, ".emoteonlyoff");
		}
	}
}
