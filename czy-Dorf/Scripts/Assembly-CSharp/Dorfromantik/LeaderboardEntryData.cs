using System;

namespace Dorfromantik
{
	[Serializable]
	public class LeaderboardEntryData
	{
		public int rank;

		public string name;

		public int score;

		public int checkScore;

		public int level;

		public int tilesPlaced;

		public int questsFulfilled;

		public int questsFailed;

		public int perfectPlacements;

		public int playtime;

		public ulong steamId;

		public int tileGenerationSeed;

		public GameModeId gameModeId;

		public int tileLimit;

		public int worldBorder;

		public string configString;

		public int year;

		public int month;
	}
}
