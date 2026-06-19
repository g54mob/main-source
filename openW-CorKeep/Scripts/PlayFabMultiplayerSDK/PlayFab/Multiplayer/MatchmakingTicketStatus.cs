namespace PlayFab.Multiplayer
{
	public enum MatchmakingTicketStatus : uint
	{
		Creating = 0u,
		Joining = 1u,
		WaitingForPlayers = 2u,
		WaitingForMatch = 3u,
		Matched = 4u,
		Canceled = 5u,
		Failed = 6u
	}
}
