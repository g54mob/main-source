using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class VIPExt
	{
		public static void VIP(this ITwitchClient client, JoinedChannel channel, string viewerToVIP)
		{
			client.SendMessage(channel, ".vip " + viewerToVIP);
		}

		public static void VIP(this ITwitchClient client, string channel, string viewerToVIP)
		{
			client.SendMessage(channel, ".vip " + viewerToVIP);
		}

		public static void UnVIP(this ITwitchClient client, JoinedChannel channel, string viewerToUnVIP)
		{
			client.SendMessage(channel, ".unvip " + viewerToUnVIP);
		}

		public static void UnVIP(this ITwitchClient client, string channel, string viewerToUnVIP)
		{
			client.SendMessage(channel, ".unvip " + viewerToUnVIP);
		}

		public static void GetVIPs(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".vips");
		}

		public static void GetVIPs(this ITwitchClient client, string channel)
		{
			client.SendMessage(channel, ".vips");
		}
	}
}
