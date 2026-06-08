using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class SubscribersOnly
	{
		public static void SubscribersOnlyOn(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".subscribers");
		}

		public static void SubscribersOnlyOn(this ITwitchClient client, string channel)
		{
			client.SendMessage(channel, ".subscribers");
		}

		public static void SubscribersOnlyOff(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".subscribersoff");
		}

		public static void SubscribersOnlyOff(this ITwitchClient client, string channel)
		{
			client.SendMessage(channel, ".subscribersoff");
		}
	}
}
