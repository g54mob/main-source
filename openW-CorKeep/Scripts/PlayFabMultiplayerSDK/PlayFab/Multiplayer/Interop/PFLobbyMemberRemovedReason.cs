namespace PlayFab.Multiplayer.Interop
{
	public enum PFLobbyMemberRemovedReason : uint
	{
		LocalUserLeftLobby = 0u,
		LocalUserForciblyRemoved = 1u,
		RemoteUserLeftLobby = 2u
	}
}
