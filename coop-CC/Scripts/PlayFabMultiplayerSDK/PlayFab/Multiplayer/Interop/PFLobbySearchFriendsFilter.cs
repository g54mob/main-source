namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbySearchFriendsFilter
	{
		public bool includeSteamFriends;

		public bool includeFacebookFriends;

		public unsafe sbyte* includeXboxFriendsToken;
	}
}
