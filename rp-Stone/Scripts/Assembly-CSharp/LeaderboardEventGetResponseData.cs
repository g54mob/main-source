public class LeaderboardEventGetResponseData
{
	public string leaderboardId;

	public int count;

	public int lastScore;

	public string lastPlayerId;

	public LeaderboardEntry[] entries;

	public bool isLastPage;

	public static LeaderboardEventGetResponseData FromJson(string sjson)
	{
		return new LeaderboardEventGetResponseData
		{
			leaderboardId = SlimJson.Parse(sjson, "\"leaderboard_id\""),
			lastScore = SlimJson.ParseInt(sjson, "\"last_score\""),
			lastPlayerId = SlimJson.Parse(sjson, "\"last_player_id\""),
			count = SlimJson.ParseInt(sjson, "\"count\""),
			entries = SlimJson.ParseArray(sjson, "\"entries\"", LeaderboardEntry.FromJson),
			isLastPage = SlimJson.ParseBool(sjson, "\"is_last_page\"")
		};
	}
}
