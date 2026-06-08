using System;
using System.Collections.Generic;
using TwitchLib.Api.Helix.Models.Users.GetUserFollows;

namespace TwitchLib.Api.Services.Events.FollowerService
{
	public class OnNewFollowersDetectedArgs : EventArgs
	{
		public string Channel;

		public List<Follow> NewFollowers;
	}
}
