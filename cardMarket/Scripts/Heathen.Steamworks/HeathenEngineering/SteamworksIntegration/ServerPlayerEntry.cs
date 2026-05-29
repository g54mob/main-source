using System;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class ServerPlayerEntry
	{
		public string name;

		public int score;

		public TimeSpan timePlayed;
	}
}
