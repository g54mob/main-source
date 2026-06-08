using System;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class TimeoutUserExt
	{
		public static void TimeoutUser(this ITwitchClient client, JoinedChannel channel, string viewer, TimeSpan duration, string message = "", bool dryRun = false)
		{
			client.SendMessage(channel, $".timeout {viewer} {duration.TotalSeconds} {message}", dryRun);
		}

		public static void TimeoutUser(this ITwitchClient client, string channel, string viewer, TimeSpan duration, string message = "", bool dryRun = false)
		{
			JoinedChannel joinedChannel = client.GetJoinedChannel(channel);
			if (joinedChannel != null)
			{
				client.TimeoutUser(joinedChannel, viewer, duration, message, dryRun);
			}
		}
	}
}
