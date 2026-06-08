using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class ClearChatExt
	{
		public static void ClearChat(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".clear");
		}

		public static void ClearChat(this ITwitchClient client, string channel)
		{
			client.SendMessage(channel, ".clear");
		}
	}
}
