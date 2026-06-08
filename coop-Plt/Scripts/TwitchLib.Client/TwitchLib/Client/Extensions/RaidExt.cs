using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class RaidExt
	{
		public static void Raid(this ITwitchClient client, JoinedChannel channel, string channelToRaid)
		{
			client.SendMessage(channel, ".raid " + channelToRaid);
		}

		public static void Raid(this ITwitchClient client, string channel, string channelToRaid)
		{
			client.SendMessage(channel, ".raid " + channelToRaid);
		}
	}
}
