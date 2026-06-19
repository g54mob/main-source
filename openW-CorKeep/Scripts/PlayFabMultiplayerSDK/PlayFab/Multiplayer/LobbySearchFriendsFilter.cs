using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbySearchFriendsFilter
	{
		private PFLobbySearchFriendsFilter filter;

		public bool IncludeSteamFriends
		{
			get
			{
				return filter.IncludeSteamFriends;
			}
			set
			{
				filter.IncludeSteamFriends = value;
			}
		}

		public bool IncludeFacebookFriends
		{
			get
			{
				return filter.IncludeFacebookFriends;
			}
			set
			{
				filter.IncludeFacebookFriends = value;
			}
		}

		public string IncludeXboxFriendsToken
		{
			get
			{
				return filter.IncludeXboxFriendsToken;
			}
			set
			{
				filter.IncludeXboxFriendsToken = value;
			}
		}

		internal LobbySearchFriendsFilter(PFLobbySearchFriendsFilter filter)
		{
			this.filter = filter;
		}
	}
}
