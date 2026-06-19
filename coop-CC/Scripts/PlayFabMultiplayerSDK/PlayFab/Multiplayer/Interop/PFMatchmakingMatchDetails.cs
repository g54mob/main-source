namespace PlayFab.Multiplayer.Interop
{
	public struct PFMatchmakingMatchDetails
	{
		public unsafe sbyte* matchId;

		public unsafe PFMatchmakingMatchMember* members;

		public uint memberCount;

		public unsafe sbyte** regionPreferences;

		public uint regionPreferenceCount;

		public unsafe sbyte* lobbyArrangementString;

		public unsafe PFMultiplayerServerDetails* serverDetails;
	}
}
