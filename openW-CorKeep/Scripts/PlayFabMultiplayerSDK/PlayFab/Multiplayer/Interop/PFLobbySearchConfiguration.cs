namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbySearchConfiguration
	{
		public unsafe PFLobbySearchFriendsFilter* friendsFilter;

		public unsafe sbyte* filterString;

		public unsafe sbyte* sortString;

		public unsafe uint* clientSearchResultCount;
	}
}
