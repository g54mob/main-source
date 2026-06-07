namespace Motorways.Leaderboards.Backends
{
	public class NullLeaderboardBackend : ILeaderboardBackend
	{
		public bool CanAuthenticate => false;

		public void RequestLocalEntry(LeaderboardId leaderboardId, LocalEntryRequestCompleted localEntryRequestCompleted)
		{
		}

		public void SubmitScore(LeaderboardId leaderboardId, int score, LeaderboardScoreState scoreState, SubmitScoreRequestCompleted submitScoreRequestCompleted)
		{
		}

		public void RequestTopEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
		}

		public void RequestPlayerCenteredEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
		}

		public void RequestTopFriendFilteredEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
		}

		public void PresentError(LeaderboardError error)
		{
		}

		public bool IsLeaderboardTypeSupported(LeaderboardType type)
		{
			return false;
		}

		public bool Authenticate(AuthenticationCompleted authenticationCompleted)
		{
			return false;
		}
	}
}
