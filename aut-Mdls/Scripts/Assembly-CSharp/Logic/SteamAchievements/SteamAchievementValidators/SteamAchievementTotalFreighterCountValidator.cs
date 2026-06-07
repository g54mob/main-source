using Presentation.Locators;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Total Freighter Count Validator", fileName = "SteamAchievementTotalFreighterCountValidator", order = 0)]
	public class SteamAchievementTotalFreighterCountValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		[SerializeField]
		private int _freightersCount;

		public override bool IsSteamAchievementReached()
		{
			return _freightersManagerLocator.Manager.ActiveFreighterCount >= _freightersCount;
		}
	}
}
