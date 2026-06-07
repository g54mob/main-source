using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/XP Rank", fileName = "SteamAchievementXPRankValidator", order = 0)]
	public class SteamAchievementXpRankValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private RankConfigSO _rankConfigSO;

		[SerializeField]
		private int _targetRank;

		public override bool IsSteamAchievementReached()
		{
			return _rankConfigSO.GetCurrentRank() >= _targetRank;
		}
	}
}
