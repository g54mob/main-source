using System;
using System.Collections.Generic;
using Factory;

namespace Motorways.Leaderboards.Backends
{
	public class RetailDemoLeaderboardBackend : ILeaderboardBackend
	{
		[Dependency]
		private ActivePlayer _player;

		public bool CanAuthenticate => false;

		public void RequestLocalEntry(LeaderboardId leaderboardId, LocalEntryRequestCompleted localEntryRequestCompleted)
		{
			if (leaderboardId is CityLeaderboardId cityLeaderboardId)
			{
				localEntryRequestCompleted(LeaderboardEntry.TestEntry("Me", LeaderboardEntryType.Local, _player.GetCityStatisticsForCity(cityLeaderboardId.City.ToString(), GameMode.Normal)?.MaxTrips ?? 0, 1L), 1L, null);
			}
			else
			{
				localEntryRequestCompleted(null, 1L, null);
			}
		}

		public void SubmitScore(LeaderboardId leaderboardId, int score, LeaderboardScoreState scoreState, SubmitScoreRequestCompleted submitScoreRequestCompleted)
		{
		}

		public void RequestTopEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
			List<LeaderboardEntry> list = new List<LeaderboardEntry>
			{
				LeaderboardEntry.TestEntry("Robena Rotolo", LeaderboardEntryType.Global, Random.Range(2500, 3000), 1L),
				LeaderboardEntry.TestEntry("Rosalina Vancleve", LeaderboardEntryType.Global, Random.Range(2300, 2499), 2L),
				LeaderboardEntry.TestEntry("Miki Varona", LeaderboardEntryType.Global, Random.Range(2100, 2299), 3L),
				LeaderboardEntry.TestEntry("Sanford Lenk", LeaderboardEntryType.Global, Random.Range(2000, 2099), 4L),
				LeaderboardEntry.TestEntry("Indira Obando", LeaderboardEntryType.Global, Random.Range(1950, 1999), 5L),
				LeaderboardEntry.TestEntry("Marguerite Kells", LeaderboardEntryType.Global, Random.Range(1920, 1949), 6L),
				LeaderboardEntry.TestEntry("Lakeesha Cieslak", LeaderboardEntryType.Global, Random.Range(1900, 1919), 7L),
				LeaderboardEntry.TestEntry("Cherri Smart", LeaderboardEntryType.Global, Random.Range(1870, 1899), 8L),
				LeaderboardEntry.TestEntry("Grady Feist", LeaderboardEntryType.Global, Random.Range(1860, 1869), 9L),
				LeaderboardEntry.TestEntry("Jeanmarie Pearce", LeaderboardEntryType.Global, Random.Range(1850, 1859), 10L),
				LeaderboardEntry.TestEntry("Me", LeaderboardEntryType.Local, 0, 0L, 0, LeaderboardScoreState.NotSubmitted)
			};
			entryRequestCompleted?.Invoke(list, list.Count, null);
		}

		public void RequestPlayerCenteredEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
			throw new NotImplementedException();
		}

		public void RequestTopFriendFilteredEntries(LeaderboardId leaderboardId, int entryCount, EntryRequestCompleted entryRequestCompleted)
		{
			throw new NotImplementedException();
		}

		public void PresentError(LeaderboardError error)
		{
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
