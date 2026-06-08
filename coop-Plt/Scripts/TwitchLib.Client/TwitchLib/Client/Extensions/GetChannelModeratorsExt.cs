using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class GetChannelModeratorsExt
	{
		public static void GetChannelModerators(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".mods");
		}

		public static void GetChannelModerators(this ITwitchClient client, string channel)
		{
			client.SendMessage(channel, ".mods");
		}
	}
}
