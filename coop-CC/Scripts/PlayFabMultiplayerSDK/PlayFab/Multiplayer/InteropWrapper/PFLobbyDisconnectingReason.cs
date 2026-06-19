namespace PlayFab.Multiplayer.InteropWrapper
{
	public enum PFLobbyDisconnectingReason : uint
	{
		NoLocalMembers = 0u,
		LobbyDeleted = 1u,
		LobbyServerLeft = 3u
	}
}
