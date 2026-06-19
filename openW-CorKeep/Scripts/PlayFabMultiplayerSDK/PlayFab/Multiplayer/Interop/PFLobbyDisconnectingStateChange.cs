namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyDisconnectingStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public unsafe PFLobby* lobby;

		public PFLobbyDisconnectingReason reason;
	}
}
