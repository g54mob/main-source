using System;
using System.Collections.Generic;
using TwitchLib.PubSub.Models;

namespace TwitchLib.PubSub.Events
{
	public class OnLeaderboardEventArgs : EventArgs
	{
		public string ChannelId;

		public List<LeaderBoard> TopList;
	}
}
