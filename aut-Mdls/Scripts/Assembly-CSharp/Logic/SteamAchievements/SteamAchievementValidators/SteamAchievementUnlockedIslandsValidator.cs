using Data.SaveData.PersistentSOs;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Unlocked islands", fileName = "SteamAchievementUnlockedIslandsValidator", order = 0)]
	public class SteamAchievementUnlockedIslandsValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private int _targetCount;

		public override bool IsSteamAchievementReached()
		{
			return _unlockedIslandsPersistentSO.UnlockedIslandCount >= _targetCount;
		}
	}
}
