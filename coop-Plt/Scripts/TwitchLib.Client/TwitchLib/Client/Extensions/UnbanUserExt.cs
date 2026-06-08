using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class UnbanUserExt
	{
		public static void UnbanUser(this ITwitchClient client, JoinedChannel channel, string viewer, bool dryRun = false)
		{
			client.SendMessage(channel, ".unban " + viewer, dryRun);
		}

		public static void UnbanUser(this ITwitchClient client, string channel, string viewer, bool dryRun = false)
		{
			JoinedChannel joinedChannel = client.GetJoinedChannel(channel);
			if (joinedChannel != null)
			{
				client.UnbanUser(joinedChannel, viewer, dryRun);
			}
		}
	}
}
