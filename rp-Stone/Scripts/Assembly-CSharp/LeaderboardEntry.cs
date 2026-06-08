using System;

public class LeaderboardEntry
{
	public string playerId;

	public string name;

	public int rank;

	public int score;

	public int time;

	public int health;

	public int damage;

	public readonly DateTime timestamp;

	public bool isLocalPlayer;

	public LeaderboardEntry()
	{
		timestamp = DateTime.Now;
	}

	public static LeaderboardEntry FromJson(string sjson)
	{
		LeaderboardEntry leaderboardEntry = new LeaderboardEntry();
		sjson = sjson.Replace("\"", "");
		leaderboardEntry.playerId = SlimJson.Parse(sjson, "player_id");
		leaderboardEntry.name = SlimJson.Parse(sjson, "player_name");
		if (leaderboardEntry.name == null)
		{
			leaderboardEntry.name = SlimJson.Parse(sjson, "name");
		}
		leaderboardEntry.rank = SlimJson.ParseInt(sjson, "rank");
		leaderboardEntry.score = SlimJson.ParseInt(sjson, "score");
		leaderboardEntry.time = SlimJson.ParseInt(sjson, "time", int.MaxValue);
		leaderboardEntry.health = SlimJson.ParseInt(sjson, "health");
		leaderboardEntry.damage = SlimJson.ParseInt(sjson, "damage");
		return leaderboardEntry;
	}
}
