using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class DeleteMessageExt
	{
		public static void DeleteMessage(this ITwitchClient client, JoinedChannel channel, string messageId)
		{
			client.SendMessage(channel, ".delete " + messageId);
		}

		public static void DeleteMessage(this ITwitchClient client, string channel, string messageId)
		{
			client.SendMessage(channel, ".delete " + messageId);
		}

		public static void DeleteMessage(this ITwitchClient client, JoinedChannel channel, ChatMessage msg)
		{
			client.SendMessage(channel, ".delete " + msg.Id);
		}

		public static void DeleteMessage(this ITwitchClient client, string channel, ChatMessage msg)
		{
			client.SendMessage(channel, ".delete " + msg.Id);
		}
	}
}
