using UnityEngine;

namespace Dorfromantik
{
	public static class BasicSteamLeaderboardValidator
	{
		public static bool IsScoreValid(LeaderboardEntryData entryToValidate, out int scorePercentage)
		{
			int num = entryToValidate.tilesPlaced * 75 + entryToValidate.perfectPlacements * 75 + entryToValidate.level * 150 + (entryToValidate.questsFulfilled - entryToValidate.level) * 100;
			scorePercentage = Mathf.RoundToInt((float)entryToValidate.score / (float)num * 100f);
			if (entryToValidate.score > num)
			{
				return false;
			}
			return true;
		}
	}
}
