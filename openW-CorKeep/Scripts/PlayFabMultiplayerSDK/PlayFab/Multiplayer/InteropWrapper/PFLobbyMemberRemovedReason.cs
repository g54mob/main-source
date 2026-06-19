namespace PlayFab.Multiplayer.InteropWrapper
{
	public enum PFLobbyMemberRemovedReason : uint
	{
		LocalUserLeftLobby = 0u,
		LocalUserForciblyRemoved = 1u,
		RemoteUserLeftLobby = 2u
	}
}
