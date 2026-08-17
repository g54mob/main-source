namespace Assets.Scripts.Steam.LeaderboardsNew;

public class LeaderboardUploadQueued
{
	public string name;

	public int score;

	public int[] details;

	public bool isFriends;

	public LeaderboardUploadQueued(string name, int score, int[] details, bool isFriends)
	{
		this.name = name;
		this.score = score;
		this.details = details;
		bool flag = default(bool);
		this.isFriends = flag;
	}
}
