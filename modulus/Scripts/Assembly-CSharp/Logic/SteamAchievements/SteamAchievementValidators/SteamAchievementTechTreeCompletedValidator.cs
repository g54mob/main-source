using Presentation.Locators;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Tech tree completed", fileName = "SteamAchievementTechTreeCompletedValidator", order = 0)]
	public class SteamAchievementTechTreeCompletedValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private TechTreeManagerLocator _techTreeManagerLocator;

		public override bool IsSteamAchievementReached()
		{
			return _techTreeManagerLocator.TechTreeManager.IsFullyCompleted;
		}
	}
}
