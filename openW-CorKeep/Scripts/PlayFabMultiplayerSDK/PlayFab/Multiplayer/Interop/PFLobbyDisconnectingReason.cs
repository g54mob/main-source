namespace PlayFab.Multiplayer.Interop
{
	public enum PFLobbyDisconnectingReason : uint
	{
		NoLocalMembers = 0u,
		LobbyDeleted = 1u,
		ConnectionInterruption = 2u,
		LobbyServerLeft = 3u
	}
}
