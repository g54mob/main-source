using Data.SaveData.PersistentSOs;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Rank 8 Island 3 Validator", fileName = "SteamAchievementRank8Island3Validator", order = 0)]
	public class SteamAchievementRank8Island3Validator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private RankConfigSO _rankConfigSo;

		[SerializeField]
		private int _requiredRank = 8;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSo;

		[SerializeField]
		private int _maxIslandCount = 3;

		public override bool IsSteamAchievementReached()
		{
			if (_rankConfigSo.GetCurrentRank() >= _requiredRank)
			{
				return _unlockedIslandsPersistentSo.UnlockedIslandCount <= _maxIslandCount;
			}
			return false;
		}
	}
}
