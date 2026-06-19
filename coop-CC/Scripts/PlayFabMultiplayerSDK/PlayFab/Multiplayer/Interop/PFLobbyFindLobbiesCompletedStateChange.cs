namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyFindLobbiesCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public PFEntityKey searchingEntity;

		public unsafe void* asyncContext;

		public uint searchResultCount;

		public unsafe PFLobbySearchResult* searchResults;
	}
}
