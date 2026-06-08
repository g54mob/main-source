using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class HostExt
	{
		public static void Host(this ITwitchClient client, JoinedChannel channel, string userToHost)
		{
			client.SendMessage(channel, ".host " + userToHost);
		}

		public static void Host(this ITwitchClient client, string channel, string userToHost)
		{
			client.SendMessage(channel, ".host " + userToHost);
		}

		public static void Unhost(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".unhost");
		}

		public static void Unhost(this ITwitchClient client, string channel)
		{
			client.SendMessage(channel, ".unhost");
		}
	}
}
