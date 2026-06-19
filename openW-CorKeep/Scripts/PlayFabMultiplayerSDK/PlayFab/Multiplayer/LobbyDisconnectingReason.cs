namespace PlayFab.Multiplayer
{
	public enum LobbyDisconnectingReason : uint
	{
		NoLocalMembers = 0u,
		LobbyDeleted = 1u,
		LobbyServerLeft = 3u
	}
}
