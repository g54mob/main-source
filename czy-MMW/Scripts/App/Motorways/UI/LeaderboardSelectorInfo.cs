using Motorways.Leaderboards;

namespace Motorways.UI
{
	public static class LeaderboardSelectorInfo
	{
		public const int NormalIndex = 0;

		public const int ExpertIndex = 1;

		public const int ChallengeOptionOffset = 2;

		public static CityGameMode GetGameModeForIndex(int selectorIndex)
		{
			return selectorIndex switch
			{
				0 => CityGameMode.Normal, 
				1 => CityGameMode.Expert, 
				_ => CityGameMode.CityChallenge, 
			};
		}
	}
}
