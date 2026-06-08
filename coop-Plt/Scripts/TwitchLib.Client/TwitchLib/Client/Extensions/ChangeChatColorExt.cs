using TwitchLib.Client.Enums;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class ChangeChatColorExt
	{
		public static void ChangeChatColor(this ITwitchClient client, JoinedChannel channel, ChatColorPresets color)
		{
			client.SendMessage(channel, $".color {color}");
		}

		public static void ChangeChatColor(this ITwitchClient client, string channel, ChatColorPresets color)
		{
			client.SendMessage(channel, $".color {color}");
		}
	}
}
