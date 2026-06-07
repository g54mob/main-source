using System;
using Factory;

namespace Motorways.Leaderboards.Backends
{
	public class SteamworksLeaderboardBackend : ILeaderboardBackend
	{
		[Dependency]
		private LeaderboardService _leaderboardService;

		public bool CanAuthenticate => false;

		public void RequestLocalEntry(LeaderboardId leaderboardId, LocalEntryRequestCompleted localEntryRequestCompleted)
		{
			SteamworksShared.RequestLocalLeaderboardEntry(GetBackendLeaderboardIdWithPrefix(leaderboardId), localEntryRequestCompleted);
		}

		public void SubmitScore(LeaderboardId leaderboardId, int score, LeaderboardScoreState scoreState, SubmitScoreRequestCompleted submitScoreRequestCompleted)
		{
			string backendLeaderboardIdWithPrefix = GetBackendLeaderboardIdWithPrefix(leaderboardId);
			SteamworksShared.SubmitScore(leaderboardId, backendLeaderboardIdWithPrefix, score, scoreState, submitScoreRequestCompleted);
		}

		public void RequestTopEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
			SteamworksShared.RequestTopLeaderboardEntries(GetBackendLeaderboardIdWithPrefix(leaderboardId), entryCount, entryRequestCompleted);
		}

		public void RequestPlayerCenteredEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
			SteamworksShared.RequestPlayerCenteredLeaderboardEntries(GetBackendLeaderboardIdWithPrefix(leaderboardId), entryCount, entryRequestCompleted);
		}

		public void RequestTopFriendFilteredEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
			SteamworksShared.RequestTopFriendLeaderboardEntries(GetBackendLeaderboardIdWithPrefix(leaderboardId), entryCount, entryRequestCompleted);
		}

		public void PresentError(LeaderboardError error)
		{
		}

		public bool IsLeaderboardTypeSupported(LeaderboardType type)
		{
			return true;
		}

		public bool Authenticate(AuthenticationCompleted authenticationCompleted)
		{
			return false;
		}

		private static string GetBackendLeaderboardIdWithPrefix(LeaderboardId leaderboardId)
		{
			string backendLeaderboardId = GetBackendLeaderboardId(leaderboardId);
			if (FeatureToggle.IsFeatureEnabled(Feature.SteamBetaLeaderboards))
			{
				return "beta_" + backendLeaderboardId;
			}
			return backendLeaderboardId;
		}

		public static string GetBackendLeaderboardId(LeaderboardId leaderboardId)
		{
			if (!(leaderboardId is CityLeaderboardId cityLeaderboardId))
			{
				if (!(leaderboardId is DailyLeaderboardId dailyLeaderboardId))
				{
					if (leaderboardId is WeeklyLeaderboardId weeklyLeaderboardId)
					{
						DateTime startOfLastOccurence = ChallengeSystem.GetStartOfLastOccurence(weeklyLeaderboardId.Week);
						return $"weekly_challenge_{startOfLastOccurence.Year:0000}-{startOfLastOccurence.Month:00}-{startOfLastOccurence.Day:00}";
					}
					Diagnostics.FailAssert("Invalid ILeaderboard derived type: {0}", leaderboardId);
					return null;
				}
				DateTime utcNow = GameDateTime.UtcNow;
				int num = utcNow.DayOfWeek - dailyLeaderboardId.Day;
				if (num < 0)
				{
					num += 7;
				}
				DateTime dateTime = utcNow.Subtract(TimeSpan.FromDays(num));
				return $"daily_challenge_{dateTime.Year:0000}-{dateTime.Month:00}-{dateTime.Day:00}";
			}
			if (cityLeaderboardId.Mode == CityGameMode.CityChallenge)
			{
				return $"{cityLeaderboardId.City.ToString().ToLower()}_{cityLeaderboardId.Mode.ToString().ToLower()}_challenge{cityLeaderboardId.CityChallengeIndex}";
			}
			CityLeaderboardId cityLeaderboardId2 = cityLeaderboardId;
			return cityLeaderboardId2.City.ToString().ToLower() + "_" + cityLeaderboardId2.Mode.ToString().ToLower();
		}
	}
}
