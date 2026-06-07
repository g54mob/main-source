using System.Collections.Generic;
using Factory;
using Motorways.Leaderboards;
using UnityEngine;

public class LeaderboardEntry
{
	public string Id { get; }

	public string Name { get; set; }

	public LeaderboardEntryType Type { get; }

	public int Score { get; }

	public long Rank { get; set; }

	public int Timestamp { get; }

	public LeaderboardScoreState ScoreState { get; }

	public LeaderboardEntry(string id, string name, LeaderboardEntryType type, int score, long rank, int timestamp, LeaderboardScoreState scoreState)
	{
		Id = id;
		Name = name;
		Type = type;
		Score = score;
		Rank = rank;
		Timestamp = timestamp;
		ScoreState = scoreState;
	}

	public static LeaderboardEntry TestEntry(string name, LeaderboardEntryType type, int score, long rank, int timeStamp = 0, LeaderboardScoreState scoreState = LeaderboardScoreState.Editable)
	{
		return new LeaderboardEntry(name, name, type, score, rank, timeStamp, scoreState);
	}

	public override bool Equals(object obj)
	{
		if (obj is LeaderboardEntry leaderboardEntry)
		{
			return leaderboardEntry.Id == Id;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}

	public StandaloneLocString FormatLocalUserString(IScope scope, long totalLeaderboardEntryCount, LeaderboardEntryFormatOptions options = (LeaderboardEntryFormatOptions)0)
	{
		StringKey stringKey = scope.Get<StringKey>();
		stringKey.InitWithStringId(StringId.You);
		StandaloneLocString standaloneLocString = StandaloneLocString.CreateString(scope, stringKey);
		string text = standaloneLocString.ToString();
		if (options.HasFlag(LeaderboardEntryFormatOptions.BoldYou))
		{
			text = "<b>" + text + "</b>";
		}
		scope.Release(standaloneLocString);
		scope.Release(stringKey);
		bool num = Rank > 0;
		bool flag = Rank <= 10;
		bool flag2 = totalLeaderboardEntryCount > 10;
		if (num && (!flag || options.HasFlag(LeaderboardEntryFormatOptions.IncludePercentileInTopTen)) && flag2)
		{
			StringId percentileStringId;
			int displayPercentile = GetDisplayPercentile(Rank, totalLeaderboardEntryCount, out percentileStringId);
			StringKey stringKey2 = scope.Get<StringKey>();
			stringKey2.InitWithStringId(percentileStringId, displayPercentile, new Dictionary<string, string> { 
			{
				"Num",
				displayPercentile.ToString()
			} });
			StandaloneLocString standaloneLocString2 = StandaloneLocString.CreateString(scope, stringKey2);
			string text2 = standaloneLocString2.ToString();
			scope.Release(standaloneLocString2);
			scope.Release(stringKey2);
			text = ((!options.HasFlag(LeaderboardEntryFormatOptions.MultiLine)) ? (text + text2) : (text + "\n" + text2.TrimStart()));
		}
		return StandaloneLocString.CreateNonLocalizedString(scope, text);
	}

	public static int GetDisplayPercentile(long rank, long totalLeaderboardEntryCount, out StringId percentileStringId)
	{
		float num = (float)rank / (float)totalLeaderboardEntryCount * 100f;
		int num2 = Mathf.Clamp(Mathf.CeilToInt(num), 1, 100);
		int num3 = num2;
		percentileStringId = StringId.TopPercentile;
		if (!(num <= 5f))
		{
			num3 = Mathf.CeilToInt((float)num2 / 5f) * 5;
			if (!(num <= 50f))
			{
				percentileStringId = StringId.BottomPercentile;
				return 100 - num3 + 5;
			}
		}
		return num3;
	}

	public override string ToString()
	{
		return $"[LeaderboardEntry: ID={Id}, Name={Name}, Type={Type}, Score={Score}, Rank={Rank}, ScoreState={ScoreState}]";
	}
}
