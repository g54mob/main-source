using UnityEngine;

namespace Dorfromantik
{
	public class GameModePreset : ScriptableObject
	{
		public GameModePresetId id;

		public string configString;

		public bool hasLeaderboard;

		public LeaderboardType leaderboard;

		public virtual string GetConfigString()
		{
			return configString;
		}

		public virtual int GetSeed()
		{
			return Randomizer.GetRandomSeed();
		}
	}
}
