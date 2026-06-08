public class LeaderboardEventSubmitResponseData
{
	public string leaderboardId;

	public LeaderboardEntry entry;

	public bool success;

	public LeaderboardEventSubmitResponseData()
	{
	}

	public LeaderboardEventSubmitResponseData(string leaderboardId, bool success, LeaderboardEntry entry)
	{
		this.leaderboardId = leaderboardId;
		this.success = success;
		this.entry = entry;
	}

	public static LeaderboardEventSubmitResponseData FromJson(string sjson)
	{
		return new LeaderboardEventSubmitResponseData
		{
			leaderboardId = SlimJson.Parse(sjson, "leaderboard_id"),
			entry = LeaderboardEntry.FromJson(sjson),
			success = SlimJson.ParseBool(sjson, "success")
		};
	}
}
