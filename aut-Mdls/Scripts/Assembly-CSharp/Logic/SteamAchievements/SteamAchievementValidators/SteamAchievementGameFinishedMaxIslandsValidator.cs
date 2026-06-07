using Data.SaveData.PersistentSOs;
using Data.Variables;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Game Finished Max Islands", fileName = "SteamAchievementGameFinishedMaxIslandsValidator", order = 0)]
	public class SteamAchievementGameFinishedMaxIslandsValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private int _targetCount;

		[SerializeField]
		private BoolVariableSO _gNNGateFinishedVariableSO;

		public override bool IsSteamAchievementReached()
		{
			if (_gNNGateFinishedVariableSO.Value)
			{
				return _unlockedIslandsPersistentSO.UnlockedIslandCount <= _targetCount;
			}
			return false;
		}
	}
}
