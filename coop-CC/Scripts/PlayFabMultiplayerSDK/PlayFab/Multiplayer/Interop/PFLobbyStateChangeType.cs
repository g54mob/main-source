namespace PlayFab.Multiplayer.Interop
{
	public enum PFLobbyStateChangeType : uint
	{
		CreateAndJoinLobbyCompleted = 0u,
		JoinLobbyCompleted = 1u,
		MemberAdded = 2u,
		AddMemberCompleted = 3u,
		MemberRemoved = 4u,
		ForceRemoveMemberCompleted = 5u,
		LeaveLobbyCompleted = 6u,
		Updated = 7u,
		PostUpdateCompleted = 8u,
		Disconnecting = 9u,
		Disconnected = 10u,
		JoinArrangedLobbyCompleted = 11u,
		FindLobbiesCompleted = 12u,
		InviteReceived = 13u,
		InviteListenerStatusChanged = 14u,
		SendInviteCompleted = 15u,
		CreateAndClaimServerLobbyCompleted = 16u,
		ClaimServerLobbyCompleted = 17u,
		ServerPostUpdateCompleted = 18u,
		ServerDeleteLobbyCompleted = 19u,
		JoinLobbyAsServerCompleted = 20u,
		ServerPostUpdateAsServerCompleted = 21u,
		ServerLeaveLobbyAsServerCompleted = 22u,
		ConnectToLobbyCompleted = 23u
	}
}
