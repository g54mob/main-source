using JetBrains.Annotations;

namespace Motorways.Leaderboards
{
	public interface ILeaderboardBackend
	{
		bool CanSubmitScoresOffline => false;

		bool CanAuthenticate { get; }

		void RequestLocalEntry(LeaderboardId leaderboardId, [NotNull] LocalEntryRequestCompleted localEntryRequestCompleted);

		void SubmitScore(LeaderboardId leaderboardId, int score, LeaderboardScoreState scoreState, [NotNull] SubmitScoreRequestCompleted submitScoreRequestCompleted);

		void RequestTopEntries(LeaderboardId leaderboardId, int entryCount, [NotNull] EntryRequestCompleted entryRequestCompleted);

		void RequestPlayerCenteredEntries(LeaderboardId leaderboardId, int entryCount, [NotNull] EntryRequestCompleted entryRequestCompleted);

		void RequestTopFriendFilteredEntries(LeaderboardId leaderboardId, int entryCount, [NotNull] EntryRequestCompleted entryRequestCompleted);

		void PresentError([NotNull] LeaderboardError error);

		bool IsLeaderboardTypeSupported(LeaderboardType type);

		bool Authenticate(AuthenticationCompleted authenticationCompleted);
	}
}
