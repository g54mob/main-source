using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class MarkerExt
	{
		public static void Marker(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".marker");
		}

		public static void Marker(this ITwitchClient client, string channel)
		{
			client.SendMessage(channel, ".marker");
		}
	}
}
