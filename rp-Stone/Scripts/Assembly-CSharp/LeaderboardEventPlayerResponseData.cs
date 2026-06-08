using System;

public class LeaderboardEventPlayerResponseData
{
	public string leaderboardId;

	public LeaderboardEntry entry;

	public bool success;

	public DateTime timestamp;

	public LeaderboardEventPlayerResponseData()
	{
	}

	public LeaderboardEventPlayerResponseData(string leaderboardId, bool success, LeaderboardEntry entry)
	{
		this.leaderboardId = leaderboardId;
		this.success = success;
		this.entry = entry;
		timestamp = DateTime.Now;
	}

	public static LeaderboardEventPlayerResponseData FromJson(string sjson)
	{
		return new LeaderboardEventPlayerResponseData
		{
			leaderboardId = SlimJson.Parse(sjson, "leaderboard_id"),
			entry = LeaderboardEntry.FromJson(sjson),
			success = SlimJson.ParseBool(sjson, "success"),
			timestamp = DateTime.Now
		};
	}
}
