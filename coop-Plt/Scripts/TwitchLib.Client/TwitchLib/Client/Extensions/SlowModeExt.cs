using System;
using TwitchLib.Client.Exceptions;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class SlowModeExt
	{
		public static void SlowModeOn(this ITwitchClient client, JoinedChannel channel, TimeSpan messageCooldown)
		{
			if (messageCooldown > TimeSpan.FromDays(1.0))
			{
				throw new InvalidParameterException("The message cooldown time supplied exceeded the maximum allowed by Twitch, which is 1 day.", client.TwitchUsername);
			}
			client.SendMessage(channel, $".slow {messageCooldown.TotalSeconds}");
		}

		public static void SlowModeOn(this ITwitchClient client, string channel, TimeSpan messageCooldown)
		{
			if (messageCooldown > TimeSpan.FromDays(1.0))
			{
				throw new InvalidParameterException("The message cooldown time supplied exceeded the maximum allowed by Twitch, which is 1 day.", client.TwitchUsername);
			}
			client.SendMessage(channel, $".slow {messageCooldown.TotalSeconds}");
		}

		public static void SlowModeOff(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".slowoff");
		}

		public static void SlowModeOff(this ITwitchClient client, string channel)
		{
			client.SendMessage(channel, ".slowoff");
		}
	}
}
