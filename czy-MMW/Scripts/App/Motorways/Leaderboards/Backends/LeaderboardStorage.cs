using System;
using System.Collections.Generic;

namespace Motorways.Leaderboards.Backends
{
	internal class LeaderboardStorage
	{
		private const int InvalidEntryIndex = -1;

		private static readonly List<LeaderboardEntry> DefaultTopEntries = new List<LeaderboardEntry>
		{
			LeaderboardEntry.TestEntry("Amazing Anton", LeaderboardEntryType.Global, 1000, 1L),
			LeaderboardEntry.TestEntry("Better Betty", LeaderboardEntryType.Global, 800, 2L),
			LeaderboardEntry.TestEntry("Counted Casey", LeaderboardEntryType.Global, 700, 3L),
			LeaderboardEntry.TestEntry("Delectable Darren", LeaderboardEntryType.Global, 600, 4L),
			LeaderboardEntry.TestEntry("Terrible Tom", LeaderboardEntryType.Global, 400, 5L),
			LeaderboardEntry.TestEntry("Medicore Misty", LeaderboardEntryType.Global, 334, 6L),
			LeaderboardEntry.TestEntry("Tried-hard Tane", LeaderboardEntryType.Global, 333, 7L),
			LeaderboardEntry.TestEntry("Lacklustre Lurk", LeaderboardEntryType.Global, 332, 8L),
			LeaderboardEntry.TestEntry("Racing Ramona", LeaderboardEntryType.Global, 331, 9L),
			LeaderboardEntry.TestEntry("Lets-Go Lucy", LeaderboardEntryType.Global, 20, 10L),
			LeaderboardEntry.TestEntry("Keep-it-up Kim", LeaderboardEntryType.Global, 15, 11L),
			LeaderboardEntry.TestEntry("Participation Patrick", LeaderboardEntryType.Global, 10, 12L),
			LeaderboardEntry.TestEntry("Test User", LeaderboardEntryType.Local, 1, 13L, 0, LeaderboardScoreState.NotSubmitted)
		};

		public readonly List<LeaderboardEntry> entries = new List<LeaderboardEntry>(DefaultTopEntries);

		public int localEntryIndex = DefaultTopEntries.Count - 1;

		public LeaderboardEntry LocalEntry => entries[localEntryIndex];

		public void InsertOrUpdateEntry(string name, LeaderboardEntryType entryType, int score, int context)
		{
			score = Math.Max(score, LocalEntry.Score);
			LeaderboardService.DecodeScoreContext(context, out var timeStamp, out var scoreState);
			LeaderboardEntry newLeaderboardEntry = LeaderboardEntry.TestEntry(name, entryType, score, -1L, timeStamp, scoreState);
			int num = entries.IndexOf(newLeaderboardEntry);
			if (num != -1)
			{
				if (entries[num].ScoreState == LeaderboardScoreState.Locked)
				{
					return;
				}
				entries.RemoveAt(num);
			}
			int num2 = entries.FindIndex((LeaderboardEntry entry) => newLeaderboardEntry.Score >= entry.Score);
			if (num2 == -1)
			{
				entries.Add(newLeaderboardEntry);
			}
			else
			{
				entries.Insert(num2, newLeaderboardEntry);
			}
			for (int num3 = 0; num3 < entries.Count; num3++)
			{
				LeaderboardEntry leaderboardEntry = entries[num3];
				leaderboardEntry.Rank = num3 + 1;
				entries[num3] = leaderboardEntry;
			}
			if (entryType == LeaderboardEntryType.Local)
			{
				localEntryIndex = entries.IndexOf(newLeaderboardEntry);
			}
		}
	}
}
