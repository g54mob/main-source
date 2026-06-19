namespace PlayFab.Multiplayer
{
	public enum LobbyMemberRemovedReason : uint
	{
		LocalUserLeftLobby = 0u,
		LocalUserForciblyRemoved = 1u,
		RemoteUserLeftLobby = 2u
	}
}
