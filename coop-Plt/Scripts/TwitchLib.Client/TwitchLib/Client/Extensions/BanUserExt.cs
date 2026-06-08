using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class BanUserExt
	{
		public static void BanUser(this ITwitchClient client, JoinedChannel channel, string viewer, string message = "", bool dryRun = false)
		{
			client.SendMessage(channel, ".ban " + viewer + " " + message);
		}

		public static void BanUser(this ITwitchClient client, string channel, string viewer, string message = "", bool dryRun = false)
		{
			JoinedChannel joinedChannel = client.GetJoinedChannel(channel);
			if (joinedChannel != null)
			{
				client.BanUser(joinedChannel, viewer, message, dryRun);
			}
		}
	}
}
