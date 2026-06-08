using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class ModExt
	{
		public static void Mod(this ITwitchClient client, JoinedChannel channel, string viewerToMod)
		{
			client.SendMessage(channel, ".mod " + viewerToMod);
		}

		public static void Mod(this ITwitchClient client, string channel, string viewerToMod)
		{
			client.SendMessage(channel, ".mod " + viewerToMod);
		}

		public static void Unmod(this ITwitchClient client, JoinedChannel channel, string viewerToUnmod)
		{
			client.SendMessage(channel, ".unmod " + viewerToUnmod);
		}

		public static void Unmod(this ITwitchClient client, string channel, string viewerToUnmod)
		{
			client.SendMessage(channel, ".unmod " + viewerToUnmod);
		}
	}
}
