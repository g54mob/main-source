using Steamworks;

public class SuperBugLeaderboard
{
	public SteamLeaderboard_t steamHandle;

	public string name;

	public SuperBugLeaderboard(string leaderboardName)
	{
		name = leaderboardName;
	}
}
