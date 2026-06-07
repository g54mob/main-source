using System.Collections.Generic;
using System.Linq;

namespace Motorways.Leaderboards.Backends
{
	public class TestLeaderboardBackend : ILeaderboardBackend
	{
		private Dictionary<LeaderboardId, LeaderboardStorage> _leaderboardStorage = new Dictionary<LeaderboardId, LeaderboardStorage>();

		public bool CanAuthenticate => false;

		private LeaderboardStorage GetOrCreateLeaderboardStorage(LeaderboardId leaderboard)
		{
			if (!_leaderboardStorage.ContainsKey(leaderboard))
			{
				_leaderboardStorage.Add(leaderboard, new LeaderboardStorage());
			}
			return _leaderboardStorage[leaderboard];
		}

		public void RequestLocalEntry(LeaderboardId leaderboardId, LocalEntryRequestCompleted localEntryRequestCompleted)
		{
			LeaderboardStorage orCreateLeaderboardStorage = GetOrCreateLeaderboardStorage(leaderboardId);
			localEntryRequestCompleted(orCreateLeaderboardStorage.LocalEntry, 0L, null);
		}

		public void SubmitScore(LeaderboardId leaderboardId, int score, LeaderboardScoreState scoreState, SubmitScoreRequestCompleted submitScoreRequestCompleted)
		{
			LeaderboardStorage orCreateLeaderboardStorage = GetOrCreateLeaderboardStorage(leaderboardId);
			int context = LeaderboardService.EncodeScoreContext(leaderboardId, scoreState);
			orCreateLeaderboardStorage.InsertOrUpdateEntry("Test User", LeaderboardEntryType.Local, score, context);
			submitScoreRequestCompleted(submittedSuccessfully: true);
		}

		public void RequestTopEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
			string leaderboardName = GetLeaderboardName(leaderboardId);
			LeaderboardStorage orCreateLeaderboardStorage = GetOrCreateLeaderboardStorage(leaderboardId);
			List<LeaderboardEntry> list = orCreateLeaderboardStorage.entries.Take(entryCount).ToList();
			LeaderboardEntry leaderboardEntry = list[0];
			leaderboardEntry.Name = leaderboardName + " Master";
			list[0] = leaderboardEntry;
			if (orCreateLeaderboardStorage.localEntryIndex > entryCount)
			{
				list.Add(orCreateLeaderboardStorage.LocalEntry);
			}
			ReturnCompletedRequest(entryRequestCompleted, list, orCreateLeaderboardStorage.entries.Count);
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

		private void ReturnCompletedRequest(EntryRequestCompleted entryRequestCompleted, List<LeaderboardEntry> topLeaderboardEntries, int totalLeaderboardEntryCount)
		{
			entryRequestCompleted?.Invoke(topLeaderboardEntries, totalLeaderboardEntryCount, null);
		}

		private string GetLeaderboardName(LeaderboardId leaderboardId)
		{
			if (!(leaderboardId is CityLeaderboardId { City: var city }))
			{
				if (!(leaderboardId is DailyLeaderboardId { Day: var day }))
				{
					if (leaderboardId is WeeklyLeaderboardId { Week: var week })
					{
						return week.ToString();
					}
					Diagnostics.FailAssert("Invalid ILeaderboard derived type: {0}", leaderboardId);
					return null;
				}
				return day.ToString();
			}
			return city.ToString();
		}

		public bool IsLeaderboardTypeSupported(LeaderboardType type)
		{
			if (type != LeaderboardType.Histogram)
			{
				return type == LeaderboardType.Global;
			}
			return true;
		}

		public bool Authenticate(AuthenticationCompleted authenticationCompleted)
		{
			return false;
		}
	}
}
