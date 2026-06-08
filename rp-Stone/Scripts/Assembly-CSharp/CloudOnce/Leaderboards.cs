using System.Collections.Generic;
using CloudOnce.Internal;

namespace CloudOnce
{
	public static class Leaderboards
	{
		private static readonly Dictionary<string, UnifiedLeaderboard> s_leaderboardDictionary = new Dictionary<string, UnifiedLeaderboard>();

		public static string GetPlatformID(string internalId)
		{
			if (!s_leaderboardDictionary.ContainsKey(internalId))
			{
				return string.Empty;
			}
			return s_leaderboardDictionary[internalId].ID;
		}
	}
}
