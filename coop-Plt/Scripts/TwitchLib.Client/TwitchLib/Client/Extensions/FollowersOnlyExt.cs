using System;
using TwitchLib.Client.Exceptions;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class FollowersOnlyExt
	{
		private const int MaximumDurationAllowedDays = 90;

		public static void FollowersOnlyOn(this ITwitchClient client, JoinedChannel channel, TimeSpan requiredFollowTime)
		{
			if (requiredFollowTime > TimeSpan.FromDays(90.0))
			{
				throw new InvalidParameterException("The amount of time required to chat exceeded the maximum allowed by Twitch, which is 3 months.", client.TwitchUsername);
			}
			string text = $"{requiredFollowTime.Days}d {requiredFollowTime.Hours}h {requiredFollowTime.Minutes}m";
			client.SendMessage(channel, ".followers " + text);
		}

		public static void FollowersOnlyOn(this ITwitchClient client, string channel, TimeSpan requiredFollowTime)
		{
			if (requiredFollowTime > TimeSpan.FromDays(90.0))
			{
				throw new InvalidParameterException("The amount of time required to chat exceeded the maximum allowed by Twitch, which is 3 months.", client.TwitchUsername);
			}
			string text = $"{requiredFollowTime.Days}d {requiredFollowTime.Hours}h {requiredFollowTime.Minutes}m";
			client.SendMessage(channel, ".followers " + text);
		}

		public static void FollowersOnlyOff(this ITwitchClient client, JoinedChannel channel)
		{
			client.SendMessage(channel, ".followersoff");
		}

		public static void FollowersOnlyOff(this TwitchClient client, string channel)
		{
			client.SendMessage(channel, ".followersoff");
		}
	}
}
